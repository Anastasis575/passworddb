class DbContext
{
    private static DbContext? instance = null;
    private DbContext()
    {
        //TODO: Add db connection
    }

    public static DbContext Get()
    {
        instance ??= new DbContext();
        return instance;
    }


}