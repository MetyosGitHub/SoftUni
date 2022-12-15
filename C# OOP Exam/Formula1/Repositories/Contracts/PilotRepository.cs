using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories.Contracts
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;
        public PilotRepository()
        {
            models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models { get { return this.models.AsReadOnly(); } }

        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return models.FirstOrDefault(e => e.GetType().Name == name);
        }

        internal object FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IPilot model)
        {
            return models.Remove(model);
        }
    }
}
