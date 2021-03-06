﻿using Contract.Enum;
using Contract.Params;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using System.Net;
using System.Web.Mvc;

namespace AplikacjaLingwistyczna.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueApplication _issueApp;

        public IssueController(IFactory factory)
        {
            _issueApp = factory.GetIssueApplication;
        }

        public ActionResult GetPage(int dialogueId, int page = 1)
        {
            var data =  _issueApp.GetPage(dialogueId, page);

            return View(data.PageData);
        }


        [HttpPost]
        public ActionResult CreateIssue([Bind(Include = "Id,Text,IssueNr,Id,DialogueId,ActorId")] Issue model)
        {
            if (ModelState.IsValid)
            {
                _issueApp.Add(model);
            }
            return RedirectToAction("EditView", "Dialogue", new { id = model.DialogueId, activeWindow = DialogueEditWindow.IssueWindow });

        }

        public ActionResult Delete(int positionId, int idDialogue)
        {
            _issueApp.Remove(new IssueParams
            {
                DialogueId = idDialogue,
                PositionId = positionId }
            );
            return RedirectToAction("EditView", "Dialogue", new { id = idDialogue, activeWindow = DialogueEditWindow.IssueWindow });
        }

        public ActionResult ChangePosition(int positionId, int idDialogue, int direction)
        {
            _issueApp.ChangePosition(new IssueParams
            {
                DialogueId = idDialogue,
                PositionId = positionId,
                Direction = direction
            });
            return RedirectToAction("EditView", "Dialogue", new { id = idDialogue, activeWindow = DialogueEditWindow.IssueWindow });
        }

        [HttpGet]
        public ActionResult Edit(int positionId, int idDialogue)
        {
            var response = _issueApp.GetOne(new IssueParams
            {
                DialogueId = idDialogue,
                PositionId = positionId
            });
            if (response == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(response.Data);
        }
        [HttpPost]
        public ActionResult Edit(Issue model)
        {
            if (ModelState.IsValid)
            {
                _issueApp.Edit(model);
                return RedirectToAction("EditView", "Dialogue", new { id = model.DialogueId, activeWindow = DialogueEditWindow.IssueWindow });
            }
            else
                return View(model);
        }
    }
}