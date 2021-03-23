using System;

public class Temprature : IComparable
{
    // This temp == 5
    // obj == 6
    // return -1

    /// <summary></summary>
    /// <param name="obj"></param>
    /// <returns>
    /// Less than zero    - The current instance precedes the object specified by the CompareTo method in the sort order.
    /// Zero              - This current instance occurs in the same position in the sort order as the object specified in the CompareTo method.
    /// Greater than zero - This current instance follows the object specified by the CompareTo method in the sort order.
    /// </returns>
    public int CompareTo(object obj)
    {
        // This should be after the passed object - 'hotter' than the passed object.
        if (obj == null)
        {
            return 1;
        }

        // Cast obj to temperature.
        Temprature otherTemp = obj as Temprature;

        if (otherTemp != null)
        {
            // Now we can compare them.
            if (this.temperature < otherTemp.temperature) return -1;
            else if (this.temperature == otherTemp.temperature) return 0;
            else return 1;
        }
        else throw new ArgumentException("Object is not a temperature.");
    }

    protected float temperature;

    public Temprature(float _temp) => temperature = _temp;

    public override string ToString()
    {
        return temperature.ToString("0.0");
    }

    /* void Start()
    {
        List<int> temp = new List<int>();
        temp.BubbleSort();
    }*/
}