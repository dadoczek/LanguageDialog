using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using AplikacjaLingwistyczna.Controllers;
using Contract.Dtos;
using Contract.Params;
using Core.Factories;
using Model.EnumType;
using Model.Models;
using Newtonsoft.Json;
using NSubstitute;
using Repo.AbstractRepo;
using Xunit;

namespace AplikacjaLingwistyczna.Tests.IntegrationTest
{
    public class DialogueIntegrationTest
    {

    //    [Fact]
    //    public void Get_Page_Dialogue_Test()
    //    {
    //        FakeDialogueRepository.Dialogues.AddRange(new[]
    //        {
    //            new Dialogue
    //            {
    //                Id = 1,
    //                Name = "Dialogue 1",
    //                Status = DialogueStatus.Pubish
    //            },
    //            new Dialogue
    //            {
    //                Id = 2,
    //                Name = "Dialogue 1",
    //                Status = DialogueStatus.Pubish
    //            },
    //            new Dialogue
    //            {
    //                Id = 3,
    //                Name = "Dialogue 1",
    //                Status = DialogueStatus.Pubish
    //            },
    //            new Dialogue
    //            {
    //                Id = 4,
    //                Name = "Dialogue 1",
    //                Status = DialogueStatus.Pubish
    //            },
    //            new Dialogue
    //            {
    //                Id = 5,
    //                Name = "Dialogue 1",
    //                Status = DialogueStatus.Pubish
    //            },
    //            new Dialogue
    //            {
    //                Id = 6,
    //                Name = "Dialogue 1",
    //                Status = DialogueStatus.Pubish
    //            },
    //        });

    //        var factory = new FactoryFake();
    //        var controller = new DialogueController(factory);
    //        var serializer = new JavaScriptSerializer();
    //        var sort = new DialoguePageParams()
    //        {
    //            SizePage = 5,
    //        };

    //        var result = controller.ViewPage(sort);


    //        Assert.NotNull(result);

    //        var json = serializer.Serialize(result);
    //        var model = serializer.Deserialize<DialoguePageDto>(json);

    //        Assert.Equal(model.Dialogues.Count, 5);
    //        Assert.True(model.Paging.IsNextPage);
    //        Assert.False(model.Paging.IsPreviousPage);
    //    }
    }
}
