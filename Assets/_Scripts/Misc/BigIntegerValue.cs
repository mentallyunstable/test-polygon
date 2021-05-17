using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class BigIntegerValue
{
    public delegate void ValueChangeEvent(BigInteger value);
    public event ValueChangeEvent OnValueChange;

    public BigInteger Value { get; private set; } = new BigInteger(0);

    public BigIntegerValue() { }
    public BigIntegerValue(string value)
    {
        Value = BigInteger.Parse(value);
    }

    private BigIntegerValue Add(BigInteger value)
    {
        Value += value;
        return this;
    }

    private BigIntegerValue Sub(BigInteger value)
    {
        Value -= value;
        return this;
    }

    public override bool Equals(object obj)
    {
        return obj is BigIntegerValue value &&
               Value.Equals(value.Value);
    }

    public override int GetHashCode()
    {
        return -1937169414 + Value.GetHashCode();
    }

    public static BigIntegerValue operator +(BigIntegerValue v1, BigInteger v2)
    {
        return v1.Add(v2);
    }

    public static BigIntegerValue operator -(BigIntegerValue v1, BigInteger v2)
    {
        return v1.Sub(v2);
    }

    public static bool operator ==(BigIntegerValue v1, BigInteger v2)
    {
        return v1.Value == v2;
    }

    public static bool operator !=(BigIntegerValue v1, BigInteger v2)
    {
        return v1.Value != v2;
    }

    public static bool operator <(BigIntegerValue v1, BigInteger v2)
    {
        return v1.Value < v2;
    }

    public static bool operator >(BigIntegerValue v1, BigInteger v2)
    {
        return v1.Value > v2;
    }
}
