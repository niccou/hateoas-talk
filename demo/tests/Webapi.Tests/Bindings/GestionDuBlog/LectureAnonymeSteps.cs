using TechTalk.SpecFlow;
using WebApi.Tests.Shared;

namespace WebApi.Tests.Bindings.GestionDuBlog
{
    [Binding, Scope(Tag = "Anonyme")]
    public class LectureAnonymeSteps : BackgroundSteps
    {
        public LectureAnonymeSteps(ScenarioContext context, ApiServer server) : base(context, server) { }

        [Given("Je suis anonyme")]
        public void GivenJeSuisAnonyme()
        {
            CurrentAuthor = new Core.Models.Author();
        }
    }
}
