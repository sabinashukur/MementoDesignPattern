
namespace MementoDesignPattern
{
    //First, let's create our Originator participant, the class SalesProspect, which will create and use Mementos:
    public class SalesProspect
    {
        string? name;
        string? phone;
        double budget;

        // Gets or sets name

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Console.WriteLine("Name:   " + name);
            }
        }

        // Gets or sets phone

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                Console.WriteLine("Phone:  " + phone);
            }
        }
        // Gets or sets budget

        public double Budget
        {
            get { return budget; }
            set
            {
                budget = value;
                Console.WriteLine("Budget: " + budget);
            }
        }

        // Stores memento

        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(name, phone, budget);
        }

        // Restores memento

        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            Name = memento.Name;
            Phone = memento.Phone;
            Budget = memento.Budget;
        }
    }

   //We need memento class that stores internal state of the Originator object.
    public class Memento
    {
        string name;
        string phone;
        double budget;

        // Constructor

        public Memento(string name, string phone, double budget)
        {
            this.name = name;
            this.phone = phone;
            this.budget = budget;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public double Budget
        {
            get { return budget; }
            set { budget = value; }
        }
    }

   // We need our Caretaker, which stores the Mementos but never inspects or modifies them. We named this class ProspectMemory :

    public class ProspectMemory
    {
        Memento? memento;

        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            //we can simulate adding a new SalesProspect
            // then using the Memento to restore the old data:
            SalesProspect s = new();
            s.Name = "Azer Aliyev";
            s.Phone = "(055) 232-24-45";
            s.Budget = 27000.0;

            // Store internal state

            ProspectMemory m = new();
            m.Memento = s.SaveMemento();

            // Continue changing originator

            s.Name = "Nigar Hasanova";
            s.Phone = "(070) 324-71-34";
            s.Budget = 1000000.0;

            // Restore saved state

            s.RestoreMemento(m.Memento);

            // Wait for user

            Console.ReadKey();
        }
    }
}
