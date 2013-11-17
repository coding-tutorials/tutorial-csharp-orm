using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public abstract class Entity<ModelEntity,DalEntity>
    {
        protected abstract ModelEntity DalEntityToModelEntity(DalEntity dalEntity);
        protected abstract DalEntity ModelEntityToDalEntity(ModelEntity modelEntity);

        protected List<ModelEntity> DalEntityListToModelEntityList(List<DalEntity> dalEntityList)
        {
            List<ModelEntity> modelList = new List<ModelEntity>();

            for (int i = 0; i < dalEntityList.Count; i++)
            {
                modelList.Add(this.DalEntityToModelEntity(dalEntityList[i]));
            }

            return modelList;
        }

        protected List<DalEntity> ModelEntityListToDalEntityList(List<ModelEntity> modelEntityList)
        {
            List<DalEntity> dalEntityList = new List<DalEntity>();

            for (int i = 0; i < modelEntityList.Count; i++)
            {
                dalEntityList.Add(this.ModelEntityToDalEntity(modelEntityList[i]));
            }

            return dalEntityList;
        }
    }
}
