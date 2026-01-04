namespace WebApiAkademic.Controllers
{
    public interface IEntityControllerInfo
    {
        public string FriendlyTableName { get; }
        public string FriendlyPKName { get; }
    }
}
