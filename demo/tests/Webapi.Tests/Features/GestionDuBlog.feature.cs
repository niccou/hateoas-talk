﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.6.0.0
//      SpecFlow Generator Version:3.6.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace WebApi.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.6.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class GestionDuBlogFeature : object, Xunit.IClassFixture<GestionDuBlogFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "GestionDuBlog.feature"
#line hidden
        
        public GestionDuBlogFeature(GestionDuBlogFeature.FixtureData fixtureData, WebApi_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Gestion du blog", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Author",
                        "State",
                        "Title",
                        "Description"});
            table1.AddRow(new string[] {
                        "Andy Bloch",
                        "Draft",
                        "New Book: Life Lessons: Hold’em Poker Style",
                        "Lorem ipsum dolor sit amet."});
            table1.AddRow(new string[] {
                        "Andy Bloch",
                        "Published",
                        "Poker and Blackjack training available",
                        "Sed vel odio consequat nunc viverra mollis."});
            table1.AddRow(new string[] {
                        "Daniel Negreanu",
                        "Draft",
                        "The WSOP POY Oopsie!",
                        "Phasellus a est sed tellus blandit cursus mollis eget odio."});
            table1.AddRow(new string[] {
                        "Daniel Negreanu",
                        "Published",
                        "Should We Care if People in the US use a VPN?",
                        "Vivamus eu faucibus erat."});
#line 4
 testRunner.Given("Je démarre l\'api avec les posts suivant", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="En tant qu\'anonyme je ne peux voir que la liste des")]
        [Xunit.TraitAttribute("FeatureTitle", "Gestion du blog")]
        [Xunit.TraitAttribute("Description", "En tant qu\'anonyme je ne peux voir que la liste des")]
        public virtual void EnTantQuanonymeJeNePeuxVoirQueLaListeDes()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("En tant qu\'anonyme je ne peux voir que la liste des", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 12
 testRunner.Given("Je suis anonyme", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 13
 testRunner.When("Je veux voir le blog", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 14
 testRunner.Then("Je recois une liste de posts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Author",
                            "Title",
                            "Description"});
                table2.AddRow(new string[] {
                            "Andy Bloch",
                            "Poker and Blackjack training available",
                            "Sed vel odio consequat nunc viverra mollis."});
                table2.AddRow(new string[] {
                            "Daniel Negreanu",
                            "Should We Care if People in the US use a VPN?",
                            "Vivamus eu faucibus erat."});
#line 15
 testRunner.And("Je vois uniquement les posts", ((string)(null)), table2, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.6.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GestionDuBlogFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GestionDuBlogFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
