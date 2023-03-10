using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories.Contracts
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models { get { return this.models.AsReadOnly(); } }

        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
            
        }

        public IFormulaOneCar FindByName(string name)
        {

            return models.FirstOrDefault(e => e.GetType().Name == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return models.Remove(model);
        }
    }
}
