﻿using Luck.Framework.Extensions;

namespace Luck.Walnut.Dto.Applications
{
    public class ApplicationOutputDto:ApplicationBaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// 应用状态
        /// </summary>
        public string ApplicationStateName => ApplicationState.ToDescription();
    }
}
