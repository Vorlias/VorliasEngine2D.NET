﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andromeda2D.Entities.Components
{

    public interface IComponent
    {
        Entity Entity
        {
            get;
        }

        /// <summary>
        /// Whether or not the component
        /// </summary>
        bool AllowsMultipleInstances
        {
            get;
        }

        string Name
        {
            get;
        }

        /// <summary>
        /// Called when the component is added to an entity
        /// </summary>
        /// <param name="entity">The entity it is added to</param>
        /// <exception cref="SetEntityInvalidException">Called if the user tries to set it</exception>
        void ComponentInit(Entity entity);
        void OnComponentCopy(Entity source, Entity copy);
    }
}
