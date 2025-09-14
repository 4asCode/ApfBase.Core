namespace DataBaseModels.ApfBaseEntities
{
    public partial class BranchGroupVsBranchGroupScheme : IEntity
    {
        public void Remove() 
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                var dbSet = context.Set<BranchGroupVsBranchGroupScheme>();

                var removeEntity = dbSet.Find(Id);

                if (removeEntity != null)
                {
                    dbSet.Remove(removeEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}
