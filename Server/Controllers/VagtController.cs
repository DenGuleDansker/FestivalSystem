﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using Common.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [ApiController]
    [Route("api/vagter")]
    public class VagtController : ControllerBase
    {
        private IVagt myRepo;

        public VagtController(IVagt myRepo)
        {
            this.myRepo = myRepo;
        }
        // GET: api/<Vagter>
        [HttpGet]
        public IEnumerable<Vagt> GetVagter()
        {
            Console.WriteLine("get ");
            return myRepo.getAll();
        }

        // En metode, der håndterer HTTP POST requests til /api/Booking
        [HttpPost]
        [Route ("ny")]
        public void AddVagt(Vagt vagt)
        {
            // Skriver en besked til konsollen med bookingens ID
            Console.WriteLine("post " + vagt.ID);
            // Tilføjer bookingen til databasen gennem vores repository
            myRepo.AddVagt(vagt);
        }

        // En metode, der håndterer HTTP DELETE requests til /api/Booking/{Id}
        [HttpDelete]
        [Route("{Id}")]
        public void DeleteVagt(int ID)
        {
            // Skriver en besked til konsollen om at bookingen er blevet slettet
            Console.WriteLine("Deleted");
            // Sletter bookingen fra databasen gennem vores repository
            myRepo.DeleteVagt(ID);
        }
    }
}
