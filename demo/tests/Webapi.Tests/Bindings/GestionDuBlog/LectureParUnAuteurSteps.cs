using TechTalk.SpecFlow;
using WebApi.Core.Models;
using WebApi.Tests.Shared;

namespace WebApi.Tests.Bindings.GestionDuBlog
{
    [Binding, Scope(Tag = "Auteur")]
    public class LectureParUnAuteurSteps : BackgroundSteps
    {
        protected LectureParUnAuteurSteps(ScenarioContext context, ApiServer server) : base(context, server) { }

        [Given("Je suis (.*)")]
        public void GivenJeSuisUnAuteur(string auteur)
        {
            CurrentAuthor = new Author { Name = auteur };
        }
    }
}
