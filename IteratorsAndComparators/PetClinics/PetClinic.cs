using System;
using System.Linq;
using System.Text;

public class PetClinic
{
    private Pet[] pets;

    public PetClinic(string name, int numberOfRooms)
    {
        ValidateRoomCount(numberOfRooms);
        this.pets = new Pet[numberOfRooms];
        this.Name = name;
    }

    public int Center => this.pets.Length / 2;

    public string Name { get;}

    public bool HasEmptyRooms => this.pets.Any(p => p == null);

    public bool Add(Pet pet)
    {
        int currentRoom = this.Center;

        for (int i = 0; i < this.pets.Length; i++)
        {
            if (i % 2 != 0)
            {
                currentRoom -= i;
            }
            else
            {
                currentRoom += i;
            }

            if (this.pets[currentRoom] == null)
            {
                pets[currentRoom] = pet;
                return true;
            }
        }

        return false;
    }

    public bool Release()
    {
        for (int i = 0; i < this.pets.Length; i++)
        {
            int index = (this.Center + i) % this.pets.Length;

            if (this.pets[index] != null)
            {
                this.pets[index] = null;
                return true;
            }
        }

        return false;
    }

    public string Print(int roomNumber)
    {
        return this.pets[roomNumber - 1]?.ToString() ?? "Room empty";
    }

    public string PrintAll()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= this.pets.Length; i++)
        {
            sb.AppendLine(this.Print(i));
        }

        string result = sb.ToString().TrimEnd();
        return result;
    }

    private void ValidateRoomCount(int numberOfRooms)
    {
        if (numberOfRooms % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }
}

