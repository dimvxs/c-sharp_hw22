using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;

namespace hw
{
    public delegate void AccountAction(string msg);
    public class CreditCard
    {
// Задание 3
// Создайте класс «Кредитная карточка». Класс должен содержать:
// ■ Номер карты;
// ■ ФИО владельца;
// ■ Срок действия карты; ■ PIN;
// ■ Кредитный лимит;
// ■ Сумма денег.
// Создайте необходимый набор методов класса. Реализуйте события для следующих ситуаций:
// ■ Пополнение счёта;
// ■ Расход денег со счёта;
// ■ Старт использования кредитных денег; 
// ■ Достижение заданной суммы денег;
// ■ Смена PIN.

public string CardNumber { get; set; }
public string Name { get; set; }
public string IssuedBy { get; set; }
int PIN { get; set; }
public int CreditLimit { get; set; }
public double LocalMoney{ get; set; }
public event AccountAction Evnt;

public CreditCard(string card, string name, string issued, int pin, int credit, double local){
    CardNumber = card;
    Name = name;
    IssuedBy = issued;
    PIN = pin;
    LocalMoney = local;
    CreditLimit = credit;
} 

public CreditCard(){
    Random card = new Random();
    long cardL = card.Next(111111111, 999999999);
    CardNumber = cardL.ToString();

    Console.WriteLine("Enter your name: ");
    Name = Console.ReadLine();

    Console.WriteLine("issue date: ");
    IssuedBy = Console.ReadLine();

    Random pin = new Random();
    PIN = pin.Next(100, 999);
    
    Console.WriteLine("Enter your current money: ");
    string money = Console.ReadLine();
    int resMon = int.Parse(money);
    LocalMoney = resMon;
    CreditLimit = 0;

} 

public void Print(){
    Console.WriteLine("Card number:" + CardNumber + "\n");
    Console.WriteLine("Name:" + Name + "\n");
    Console.WriteLine("PIN:" + PIN + "\n");
    Console.WriteLine("Date issue:" + IssuedBy + "\n");
    Console.WriteLine("Credit limit:" + CreditLimit + "\n");
    Console.WriteLine("Local money:" + LocalMoney + "\n");
}



public void Put(int sum){
Console.WriteLine("enter a number of the card: ");
string number = Console.ReadLine();

Console.WriteLine("enter a CVV of the card: ");
string cvv = Console.ReadLine();
int pin = int.Parse(cvv);

if(number == CardNumber && pin == PIN){
LocalMoney += sum;
Evnt?.Invoke("put succeed \n");
}


}


public void Withdraw(int sum){
if(sum < LocalMoney){
    LocalMoney -= sum;
    Evnt?.Invoke("money successfully withdrawed \n");
}
}



public void ChangePin(int pin){
Console.WriteLine("enter a number of the card: ");
string number = Console.ReadLine();

Console.WriteLine("enter a PIN of the card: ");
string cvv = Console.ReadLine();
int code = int.Parse(cvv);

if(number == CardNumber && code == PIN){
    PIN = pin;
    Evnt?.Invoke("PIN-code successfully changed \n");
}
}


public void StartCredit(){
    Console.WriteLine("enter a number of the card: ");
string number = Console.ReadLine();

Console.WriteLine("enter a PIN of the card: ");
string cvv = Console.ReadLine();
int code = int.Parse(cvv);

if(number == CardNumber && code == PIN){
    CreditLimit = 100000;
    Evnt?.Invoke("You opened Credit limit \n");
}
}


public void ReturnCredit(){
Console.WriteLine("enter a number of the card: ");
string number = Console.ReadLine();

Console.WriteLine("enter a PIN of the card: ");
string cvv = Console.ReadLine();
int code = int.Parse(cvv);

if(number == CardNumber && code == PIN){
  Console.WriteLine("enter the sum you want to return: ");
  string s = Console.ReadLine();
  int sum = int.Parse(s);
  
  if(LocalMoney >= sum){
    LocalMoney -= sum;
    Evnt?.Invoke("you returned" + $"'{sum}'" + "\n");
  }

}
}




    }
}
