public class FeatureCollection
{
    public Feature[] features { get; set; }
}


public class Feature
{
    public Properties properties { get; set; }
}


public class Properties
{
    public string place { get; set; }

    public double mag { get; set; }
}
