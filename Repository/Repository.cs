using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class Repository<DalType,ModelType>
    {

        protected abstract ModelType DalToModel(DalType dal);

        protected List<ModelType> ListDalToListModel(List<DalType> dalList)
        {
            List<ModelType> listModel = new List<ModelType>();
            for(int i=0;i<dalList.Count;i++)
            {
                listModel.Add(this.DalToModel(dalList[i]));
            }

            return listModel;
        }

        
    }
}
