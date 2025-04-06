
using aa_interview.Models;

namespace aa_interview.Services
{
    public class AddressBookService
    {
        private readonly List<AddressBookEntry> _entries = new List<AddressBookEntry>();
        private int lastId = 0; // Start at 0, but increment as we add (quick solution)

        public AddressBookService()
        {
            
        }

        public IEnumerable<AddressBookEntry> GetAllEntries()
        {
            return _entries;
        }

        public AddressBookEntry GetEntry(int id)
        {
            return _entries.FirstOrDefault(e => e.Id == id);
        }

        public AddressBookEntry AddEntry(AddressBookEntry entry)
        {
            entry.Id = lastId;
            if (entry != null)
            {
                _entries.Add(entry);
                lastId += 1;
            }
            return entry;
        }

        public int UpdateEntry(AddressBookEntry entry)
        {
            var existingEntry = GetEntry(entry.Id);
          
            existingEntry.Name = entry.Name;
            existingEntry.Email = entry.Email;
            existingEntry.PhoneNumber = entry.PhoneNumber;
            
            return 1;
        }

        public int DeleteEntry(int id)
        {
            var entry = GetEntry(id);
            if (entry != null)
            {
                _entries.Remove(entry);
            } else {
                return 0;
            }
            return 1;
        }
    }
}