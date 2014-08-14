using System;
using System.Web.UI;
using InstantAnswer.Service;

namespace InstantAnswer.WebApp
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void queryButton_Click(object sender, EventArgs e)
        {
            var queryService = new QueryService();
            DuckDuckGoResponse duckDuckGoResponse = queryService.Query(queryTextBox.Text);

            switch (duckDuckGoResponse.Type)
            {
                case "A":
                    answerAbstractText.Text = duckDuckGoResponse.AbstractText;
                    answerHeading.Text = duckDuckGoResponse.Heading;
                    answerImage.ImageUrl = duckDuckGoResponse.Image;

                    break;
                case "D":
                    duplicateAnswers.DataSource = duckDuckGoResponse.RelatedTopics;
                    duplicateAnswers.DataBind();

                    break;
                default:
                    noAnswerLabel.Text = String.Format("Unable to locate answer for '{0}'", queryTextBox.Text);

                    break;
            }
        }
    }
}