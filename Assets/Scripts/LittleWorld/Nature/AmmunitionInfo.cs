using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWorld.Item
{
    public class AmmunitionInfo : BaseInfo
    {
        /// <summary>
        /// 口径
        /// </summary>
        public string caliber;
        /// <summary>
        /// 在哪里生产
        /// </summary>
        public int createAt;
        /// <summary>
        /// 生产工作量
        /// </summary>
        public int workToMake;
        /// <summary>
        /// 伤害
        /// </summary>
        public float damge;
    }
}
