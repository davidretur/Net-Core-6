using crudAdoRes.Models;
using Microsoft.AspNetCore.Mvc;

namespace crudAdoRes.Controllers
{
    public class GroupMeetingController : Controller
    {
        public IActionResult Index()
        {
            return View(DGroupMeeting.GetGroupMeetings());
        }
        [HttpGet]
        public IActionResult AddGroupMeeting()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGroupMeeting([Bind] GroupMeeting groupMeeting)
        {
            if (ModelState.IsValid)
            {
                if (DGroupMeeting.AddGroupMeeting(groupMeeting) > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(groupMeeting);
        }

        [HttpGet]
        public IActionResult EditMeeting(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GroupMeeting group = DGroupMeeting.GetGroupMeetingById(id);
            if (group == null)
                return NotFound();
            return View(group);
        }

        [HttpPost]
        public IActionResult EditMeeting(int id, [Bind] GroupMeeting groupMeeting)
        {
            if (id != groupMeeting.GroupMeetingId)
                return NotFound();

            if (ModelState.IsValid)
            {
                DGroupMeeting.UpdateGroupMeeting(groupMeeting);
                return RedirectToAction("Index");
            }
            return View(groupMeeting);
        }
        [HttpGet]
        public IActionResult DeleteMeeting(int id)
        {
            GroupMeeting group = DGroupMeeting.GetGroupMeetingById(id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }
        [HttpPost]
        public IActionResult DeleteMeeting(int id, GroupMeeting groupMeeting)
        {
            if (DGroupMeeting.DeleteGroupMeeting(id) > 0)
            {
                return RedirectToAction("Index");
            }
            return View(groupMeeting);
        }
    }
}
