using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectCV.Models.Entity;

namespace ProjectCV.Models.Class
{
    public class Class1
    {
        public IEnumerable<TblAbout> Value1 { get; set; }
        public IEnumerable<TblExperience> Value2 { get; set; }
        public IEnumerable<TblEducation> Value3 { get; set; }
        public IEnumerable<TblSkill> Value4 { get; set; }
        public IEnumerable<TblReference> Value5 { get; set; }
        public IEnumerable<TblProject> Value6 { get; set; }
        public IEnumerable<TblAboutPerson> Value7 { get; set; }
    }
}