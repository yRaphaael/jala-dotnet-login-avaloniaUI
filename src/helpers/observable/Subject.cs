using System;
using System.Collections.Generic;

public class Subject
{
    private readonly List<IObservable> observers = [];

    public void Attach(IObservable observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObservable observer)
    {
        observers.Remove(observer);
    }

    public void Notify(string message)
    {
        try {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        } catch (Exception err) {
            Console.WriteLine(err.Message);
        }
    }
}
