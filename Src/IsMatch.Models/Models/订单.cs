using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace IsMatch.Models
{
    /// <summary>订单</summary>
    [Serializable]
    [DataObject]
    [Description("订单")]
    [BindTable("Orders", Description = "订单", ConnName = "Conn", DbType = DatabaseType.None)]
    public partial class Orders
    {
        #region 属性
        private String _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn("ID", "编号", "")]
        public String ID { get => _ID; set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } } }

        private Int32 _GoodsID;
        /// <summary>商品ID</summary>
        [DisplayName("商品ID")]
        [Description("商品ID")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("GoodsID", "商品ID", "")]
        public Int32 GoodsID { get => _GoodsID; set { if (OnPropertyChanging("GoodsID", value)) { _GoodsID = value; OnPropertyChanged("GoodsID"); } } }

        private String _SerialNumber;
        /// <summary>订单号</summary>
        [DisplayName("订单号")]
        [Description("订单号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("SerialNumber", "订单号", "")]
        public String SerialNumber { get => _SerialNumber; set { if (OnPropertyChanging("SerialNumber", value)) { _SerialNumber = value; OnPropertyChanged("SerialNumber"); } } }

        private String _PlaceOrder;
        /// <summary>下单账号</summary>
        [DisplayName("下单账号")]
        [Description("下单账号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("PlaceOrder", "下单账号", "")]
        public String PlaceOrder { get => _PlaceOrder; set { if (OnPropertyChanging("PlaceOrder", value)) { _PlaceOrder = value; OnPropertyChanged("PlaceOrder"); } } }

        private String _VideoNo;
        /// <summary>作品Id</summary>
        [DisplayName("作品Id")]
        [Description("作品Id")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("VideoNo", "作品Id", "")]
        public String VideoNo { get => _VideoNo; set { if (OnPropertyChanging("VideoNo", value)) { _VideoNo = value; OnPropertyChanged("VideoNo"); } } }

        private Int32 _Nums;
        /// <summary>数量</summary>
        [DisplayName("数量")]
        [Description("数量")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Nums", "数量", "")]
        public Int32 Nums { get => _Nums; set { if (OnPropertyChanging("Nums", value)) { _Nums = value; OnPropertyChanged("Nums"); } } }

        private Int32 _Status;
        /// <summary>状态</summary>
        [DisplayName("状态")]
        [Description("状态")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Status", "状态", "")]
        public Int32 Status { get => _Status; set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } } }

        private Double _Money;
        /// <summary>金额</summary>
        [DisplayName("金额")]
        [Description("金额")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Money", "金额", "")]
        public Double Money { get => _Money; set { if (OnPropertyChanging("Money", value)) { _Money = value; OnPropertyChanged("Money"); } } }

        private String _CreateIP;
        /// <summary>下单Ip</summary>
        [DisplayName("下单Ip")]
        [Description("下单Ip")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateIP", "下单Ip", "")]
        public String CreateIP { get => _CreateIP; set { if (OnPropertyChanging("CreateIP", value)) { _CreateIP = value; OnPropertyChanged("CreateIP"); } } }

        private DateTime _CreateTime;
        /// <summary>时间</summary>
        [DisplayName("时间")]
        [Description("时间")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("CreateTime", "时间", "")]
        public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

        private String _Remark;
        /// <summary>详细信息</summary>
        [DisplayName("详细信息")]
        [Description("详细信息")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn("Remark", "详细信息", "")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case "ID": return _ID;
                    case "GoodsID": return _GoodsID;
                    case "SerialNumber": return _SerialNumber;
                    case "PlaceOrder": return _PlaceOrder;
                    case "VideoNo": return _VideoNo;
                    case "Nums": return _Nums;
                    case "Status": return _Status;
                    case "Money": return _Money;
                    case "CreateIP": return _CreateIP;
                    case "CreateTime": return _CreateTime;
                    case "Remark": return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "ID": _ID = Convert.ToString(value); break;
                    case "GoodsID": _GoodsID = value.ToInt(); break;
                    case "SerialNumber": _SerialNumber = Convert.ToString(value); break;
                    case "PlaceOrder": _PlaceOrder = Convert.ToString(value); break;
                    case "VideoNo": _VideoNo = Convert.ToString(value); break;
                    case "Nums": _Nums = value.ToInt(); break;
                    case "Status": _Status = value.ToInt(); break;
                    case "Money": _Money = value.ToDouble(); break;
                    case "CreateIP": _CreateIP = Convert.ToString(value); break;
                    case "CreateTime": _CreateTime = value.ToDateTime(); break;
                    case "Remark": _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得订单字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            /// <summary>商品ID</summary>
            public static readonly Field GoodsID = FindByName("GoodsID");

            /// <summary>订单号</summary>
            public static readonly Field SerialNumber = FindByName("SerialNumber");

            /// <summary>下单账号</summary>
            public static readonly Field PlaceOrder = FindByName("PlaceOrder");

            /// <summary>作品Id</summary>
            public static readonly Field VideoNo = FindByName("VideoNo");

            /// <summary>数量</summary>
            public static readonly Field Nums = FindByName("Nums");

            /// <summary>状态</summary>
            public static readonly Field Status = FindByName("Status");

            /// <summary>金额</summary>
            public static readonly Field Money = FindByName("Money");

            /// <summary>下单Ip</summary>
            public static readonly Field CreateIP = FindByName("CreateIP");

            /// <summary>时间</summary>
            public static readonly Field CreateTime = FindByName("CreateTime");

            /// <summary>详细信息</summary>
            public static readonly Field Remark = FindByName("Remark");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得订单字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>商品ID</summary>
            public const String GoodsID = "GoodsID";

            /// <summary>订单号</summary>
            public const String SerialNumber = "SerialNumber";

            /// <summary>下单账号</summary>
            public const String PlaceOrder = "PlaceOrder";

            /// <summary>作品Id</summary>
            public const String VideoNo = "VideoNo";

            /// <summary>数量</summary>
            public const String Nums = "Nums";

            /// <summary>状态</summary>
            public const String Status = "Status";

            /// <summary>金额</summary>
            public const String Money = "Money";

            /// <summary>下单Ip</summary>
            public const String CreateIP = "CreateIP";

            /// <summary>时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>详细信息</summary>
            public const String Remark = "Remark";
        }
        #endregion
    }
}