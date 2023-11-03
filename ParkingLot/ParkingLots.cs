﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLots
    {
        private string? car;
        private string? ticket;
        private int capacity = 10;
        private Dictionary<string?, string?> ticket2Car = new Dictionary<string?, string?>();
        public ParkingLots(int capacity)
        {
            this.capacity = capacity;
        }

        public ParkingLots()
        {
        }

        public string Fetch(string ticket)
        {
            //if (ticket2Car.ContainsKey(ticket))
            if (ticket == null)
            {
                return null;
            }

            if (!ticket2Car.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket");
            }

            this.car = ticket2Car[ticket];
            ticket2Car.Remove(ticket);
            return this.car;
        }

        public string Park(string car)
        {
            this.ticket = "T-" + car;
            capacity--;

            if (capacity <= 0)
            {
                return null;
            }
            else
            {
                ticket2Car.Add(this.ticket, car);
                this.car = car;
                return this.ticket;
            }
        }

        public string Park()
        {
            return null;
        }
    }
}
