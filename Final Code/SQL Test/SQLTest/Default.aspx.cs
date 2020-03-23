using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
namespace StrokePredictionMali
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbPredict_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/e0273ed794c94cc1aecc00dde0bd4b21/services/26dfba8555834be89315b52d43c1cf5b/execute?api-version=2.0&details=true");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "1d6d7b09-b07b-462b-aa5f-21f3176a7a01");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer 0bmlM74KgXA0xMsNLx7D2gWcWNfiBsolKZCg3NIo92giva98n4QrQbcdwRI2q8xCGRWTLH1wYET9B5DnE2rgzw==");
            request.AddParameter("undefined", "{\n  \"Inputs\": {\n    \"input1\": {\n      \"ColumnNames\": [\n        \"id\",\n        \"gender\",\n        \"age\",\n        \"hypertension\",\n        \"heart_disease\",\n        \"ever_married\",\n        \"work_type\",\n        \"Residence_type\",\n        \"avg_glucose_level\",\n        \"bmi\",\n        \"smoking_status\",\n        \"stroke\"\n      ],\n      \"Values\": [\n        [\n          \"0\",\n          \"" + rblGender.SelectedItem.Text + "\",\n          \"" + Age.Text + "\",\n          \"" + rblHypertension.SelectedItem.Text + "\",\n          \"" + rblHeartDisease.SelectedItem.Text + "\",\n          \"" + rblMaritalStatus.SelectedItem.Text + "\",\n          \"" + rblWorkType.SelectedItem.Text + "\",\n          \"" + rblResidence.SelectedItem.Text + "\",\n          \"" + Glucoselvl.Text + "\",\n          \"" + BMI.Text + "\",\n          \"" + rblSmokingStatus.SelectedItem.Text + "\",\n          \"0\"\n        ]\n      ]\n    }\n  },\n  \"GlobalParameters\": {}\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //lblResults.Text = response.Content.ToString();
            //{"Results":{"output1":{"type":"table","value":{"ColumnNames":["gender","age","hypertension","heart_disease","ever_married","work_type","Residence_type","avg_glucose_level","bmi","smoking_status","stroke","Scored Labels","Scored Probabilities"],"ColumnTypes":["String","Double","Int32","Int32","String","String","String","Double","Double","String","Int32","Int32","Double"],"Values":[["Female","65","0","0","Yes","Private","Urban","330","34","smokes","0","0","0.059025701135397"]]}}}}
            var results = JObject.Parse(response.Content);
            string prediction = results["Results"]["output1"]["value"]["Values"].ToString();
            prediction = prediction.Replace("[", "").Replace("]", "").Replace("\"", "");
            //prediction = prediction.LastIndexOf();
            lblResults.Text = "The Patient has a " + Convert.ToDecimal(prediction).ToString("#0.##%") + "chance of getting a Heart stroke";
         
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=strokepredictiondbserver.database.windows.net;Initial Catalog=StrokePredictionDB;User ID=MAYURESHMALI;Password=CAPTAIN@13");
            SqlCommand cmd = new SqlCommand("insert into StrokeDB (Gender,Age,Hypertension,HeartDisease,MaritalStatus,WorkType,ResidenceType,AverageGlucoseLevel,BMI,SmokingStatus,Probability) values (@r1,@Age,@r2,@r3,@r4,@r5,@r6,@GlucoseLvl,@BMI,@r7,@PD)", con);
            cmd.Parameters.AddWithValue("r1", rblGender.SelectedItem.Text);
            cmd.Parameters.AddWithValue("r2", rblHypertension.SelectedItem.Text);
            cmd.Parameters.AddWithValue("r3", rblHeartDisease.SelectedItem.Text);
            cmd.Parameters.AddWithValue("r4", rblMaritalStatus.SelectedItem.Text);
            cmd.Parameters.AddWithValue("r5", rblWorkType.SelectedItem.Text);
            cmd.Parameters.AddWithValue("r6", rblResidence.SelectedItem.Text);
            cmd.Parameters.AddWithValue("r7", rblSmokingStatus.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Age", Age.Text);
            cmd.Parameters.AddWithValue("@GlucoseLvl", Glucoselvl.Text);
            cmd.Parameters.AddWithValue("@BMI", BMI.Text);
            cmd.Parameters.AddWithValue("@PD", lblResults.Text);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}