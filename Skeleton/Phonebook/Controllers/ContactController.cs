﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Phonebook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Controllers
{
    public class ContactController : Controller
    {
        [HttpPost]
        public IActionResult Create (Contact contact)
        {
            DataAccess.Contacts.Add(contact);
            return RedirectToAction("Index", "Home");
        }
    }
}
