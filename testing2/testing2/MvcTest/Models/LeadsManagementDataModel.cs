using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeadsUI.Models
{
    public class LeadsManagementDataModel
    {
        public class LeadModel
        {
            public int Id { get; set; }
            public string Partner { get; set; }
            public string Statute { get; set; }
            public string FirstName { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Date { get; set; }
            public string User { get; set; }
            public string ResolutionRemarks { get; set; }
            public string Recontact { get; set; }
        }
        public class Source
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Partner
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Statute
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public List<LeadModel> LeadModelList { get; set; }
        public string QuickSearch { get; set; }
        public List<Source> Sources { get; set; }
        public int SourceId { get; set; }
        public List<Partner> Partners { get; set; }
        public List<Statute> Statutes { get; set; }
        public List<User> Users { get; set; }
        public string DateStarting { get; set; }
        public string DateUntil { get; set; }

        public int PartnerId { get; set; }

        public LeadsManagementDataModel()
        {
            this.LeadModelList = new List<LeadModel>();
            this.Sources = new List<Source>();
            this.Partners = new List<Partner>();
            this.Statutes = new List<Statute>();
            this.Users = new List<User>();
        }
        public void PopulateFieldsTest()
        {
            // create Partners
            var Partner1 = new Partner
            {
                Id = 1,
                Name = "Partner1"
            };
            var Partner2 = new Partner
            {
                Id = 2,
                Name = "Partner2"
            };
            this.Partners.Add(Partner1);
            this.Partners.Add(Partner2);

            //create sources
            var source1 = new Source
            {
                Id = 1,
                Name = "Source1"
            };

            var source2 = new Source
            {
                Id = 2,
                Name = "Source2"
            };
            this.Sources.Add(source1);
            this.Sources.Add(source2);

            // create LeadModel to be added to the table
            var LeadModel = new LeadModel
            {
                Id = 1,
                Partner = "Partner Test",
                Statute = "StatuteTest",
                FirstName = "Dan"
            };
            var LeadModel2 = new LeadModel
            {
                Id = 2,
                Partner = "Partner2 Test",
                Statute = "StatuteTest2",
                FirstName = "Dan2"
            };
            var LeadModel3 = new LeadModel
            {
                Id = 3,
                Partner = "Partner3 Test3",
                Statute = "StatuteTest3",
                FirstName = "Dan3"
            };

            this.LeadModelList.Add(LeadModel);
            this.LeadModelList.Add(LeadModel2);
            this.LeadModelList.Add(LeadModel3);
        }
    }
}