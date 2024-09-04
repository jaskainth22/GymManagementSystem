using System;
using System.Collections.Generic;

public enum WorkoutType {
    CARDIO,
    WEIGHTS
}

public class Slot {
    public string startTime {get; set;}
    public string endTime {get; set;}
    public WorkoutType workoutType {get; set;}
    public int availableSeats {get; set;}

    public Slot(string startTime, string endTime, WorkoutType workoutType, int seats) {
        this.startTime = startTime;
        this.endTime = endTime;
        this.workoutType = workoutType;
        this.availableSeats = seats;
    }
}

public class GymCenter {
    public string name {get; set;}
    public List<Slot> availableSlots {get; set;}

    public GymCenter(string name) {
        this.name = name;
        this.availableSlots = new List<Slot>();
    }
}

public class User {
    public string name;
    public int id;
    public User(string name, int id) {
        this.name = name;
        this.id = id;
    }
    public void Register() {

    }
    public void ViewWorkouts(GymCenter gym) {
        // List all the available workouts at a particular center
        Console.WriteLine("{0}", gym.name);
        for (int i=0;i<gym.availableSlots.Count;i++) {
            Console.WriteLine("{0}, {1}, {2}, {3}", gym.availableSlots[i].startTime, gym.availableSlots[i].endTime, gym.availableSlots[i].workoutType, gym.availableSlots[i].availableSeats);
        }
    }
    public void BookWorkout(GymCenter gym, Slot slot, WorkoutType workoutType) {

    }

    public void ViewHistory(int dateTime) {

    }
}

public class Admin {

    public GymCenter AddGymCenter(string name, int noofSeatsInEachSlot) {
        GymCenter gym = new GymCenter(name);
        // morning slots
        AddSlot(gym, "0600","0700", WorkoutType.CARDIO, noofSeatsInEachSlot);
        AddSlot(gym, "0700","0800", WorkoutType.CARDIO, noofSeatsInEachSlot);
        AddSlot(gym, "0800","0900", WorkoutType.CARDIO, noofSeatsInEachSlot);
        AddSlot(gym, "0600","0700", WorkoutType.WEIGHTS, noofSeatsInEachSlot);
        AddSlot(gym, "0600","0700", WorkoutType.WEIGHTS, noofSeatsInEachSlot);
        AddSlot(gym, "0600","0700", WorkoutType.WEIGHTS, noofSeatsInEachSlot);

        // evening slots
        AddSlot(gym, "1800","1900", WorkoutType.CARDIO, noofSeatsInEachSlot);
        AddSlot(gym, "1900","2000", WorkoutType.CARDIO, noofSeatsInEachSlot);
        AddSlot(gym, "2000","2100", WorkoutType.CARDIO, noofSeatsInEachSlot);
        AddSlot(gym, "1800","1900", WorkoutType.WEIGHTS, noofSeatsInEachSlot);
        AddSlot(gym, "1900","2000", WorkoutType.WEIGHTS, noofSeatsInEachSlot);
        AddSlot(gym, "2000","2100", WorkoutType.WEIGHTS, noofSeatsInEachSlot);

        return gym;
    }
    public void AddSlot(GymCenter gym, string startTime, string endTime, WorkoutType workoutType, int noofSeatsInEachSlot) {
        Slot slot = new Slot(startTime, endTime, workoutType, noofSeatsInEachSlot);
        gym.availableSlots.Add(slot);
    }
}


public class Program {
    public static void Main() {
        Admin admin = new Admin();
        GymCenter KormanaglaGym = admin.AddGymCenter("Kormangala Gym", 3);
        GymCenter IndiranagrGym = admin.AddGymCenter("Indiranagar", 3);
        User Jaskaran = new User("Jaskaran", 0);
        Jaskaran.ViewWorkouts(IndiranagrGym);
        Jaskaran.ViewWorkouts(KormanaglaGym);
    }
}