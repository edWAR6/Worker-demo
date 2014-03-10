using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataAccess.Workers
{
    public class Tour : Manager
    {
        public int ID { get; set; }
        public Nullable<int> interviewer { get; set; }
        public Nullable<DateTime> deliveryDate { get; set; }
        public Nullable<DateTime> tourDate { get; set; }
        public string description { get; set; }
        public string status { get; set; }        

        public Tour(int ID, int interviewer, DateTime deliveryDate, DateTime tourDate, string description, string status)
        {
            this.ID = ID;
            this.interviewer = interviewer;
            this.deliveryDate = deliveryDate;
            this.tourDate = tourDate;
            this.description = description;
            this.status = status;
        }

        public Tour(A_Giras a_giras)
        {
            this.ID = a_giras.Gira;
            this.interviewer = a_giras.Entrevistador;
            this.deliveryDate = a_giras.FechaEntrega;
            this.tourDate = a_giras.FechaGira;
            this.description = a_giras.Descripcion;
            this.status = a_giras.Estado;
        }

        public override bool Create()
        {
            A_Giras a_giras = new A_Giras
            {
                Gira = this.ID,
                Entrevistador = this.interviewer,
                FechaEntrega = this.deliveryDate,
                FechaGira = this.tourDate,
                Descripcion = this.description,
                Estado = this.status
            };
            context.A_Giras.Add(a_giras);
            context.SaveChanges();
            return true;
        }

        public override bool Update()
        {
            A_Giras a_giras = new A_Giras{ 
                Gira = this.ID
            };
            context.Entry(a_giras).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public override bool Detele()
        {
            A_Giras a_giras = context.A_Giras.Single(x => x.Gira == this.ID);
            context.A_Giras.Remove(a_giras);
            context.SaveChanges();
            return true;
        }

        public override Manager Get(int ID) {
            A_Giras a_giras = context.A_Giras.Single(x => x.Gira == ID);
            return new Tour(a_giras);
        }

        public override List<Manager> List()
        {
            return context.A_Giras.Select(g => (Manager)new Tour(g)).ToList();
        }
    }
}