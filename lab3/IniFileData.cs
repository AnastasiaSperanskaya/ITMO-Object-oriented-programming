using System.Collections.Generic;
using lab3.Exceptions;

namespace lab3
{
    public class IniFileData
    {
        private List<Section> Sections;

        public IniFileData()
        {
            Sections = new List<Section>();
        }
        public Section this[string name]
        {
            get
            {
                foreach (var section in Sections)
                    if (section.Name.Equals(name))
                        return section;
                
                throw new SectionNotFound();
            }
        }

        public void AddSection(string sectionName)
        {
            Sections.Add(new Section(sectionName));
        }
    }
}