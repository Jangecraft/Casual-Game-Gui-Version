public struct DataPlayer
{
    private string name;
    private string lv;
    private string maxexp;
    private string exp;

    public string Name 
    { 
        get { return name; } 
        set { name = value; }
    }
    public string Lv
    {
        get { return lv; }
        set { lv = value; }
    }
    public string MaxExp
    {
        get { return maxexp; }
        set { maxexp = value; }
    }
    public string Exp
    {
        get { return exp; }
        set { exp = value; }
    }

}