namespace MMS.Infrastructure
{
    /// <summary>
    /// 操作结果类，包含操作结果的一些必要信息(成功与否、信息、需要反馈的数据)
    /// </summary>
    public class OperateResult
    {
        /// <summary>
        /// 操作成功与否的标志
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 操作返回的信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 操作返回的数据
        /// </summary>
        public object Data { get; set; }
    }
}
