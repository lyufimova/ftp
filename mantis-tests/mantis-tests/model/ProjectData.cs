using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Mapping;


namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {

        public ProjectData()
        {
        }

        public ProjectData (string name)
        {
            Name = name;
        }

        [Column(Name = "name")]
        public string Name { get; set; }


        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        public static List<ProjectData> GetAll()
        {
            using (MantisDB db = new MantisDB())
            {
                return (from p in db.Projects select p).ToList();
            }
        }

        public bool Equals(ProjectData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return (Name == other.Name) ;
        }


        public int CompareTo(ProjectData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }

            return Name.CompareTo(other.Name);
        }

    }
}

