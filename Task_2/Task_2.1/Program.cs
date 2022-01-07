string fullName = "Соломатин Кирилл Евгеньевич";
int age = 30;
string email = "kir.solomatin@mail.ru";
double scoreOnProgramm = 4.9;
double scoreOnMath = 3.8;
double scoreOnPhysics = 4.5;
string student = "Ф.И.О.: {0} \nВозраст: {1} \nEmail: {2} \n" +
    "Баллы по программированию: {3} \nБаллы по математике: {4} \nБаллы по физике: {5}\n";

Console.WriteLine($"{student}",
    fullName,
    age,
    email,
    scoreOnProgramm,
    scoreOnMath,
    scoreOnPhysics);

Console.ReadKey();

double sumScores;
sumScores = scoreOnProgramm + scoreOnMath + scoreOnPhysics;
double averageScore;
averageScore = sumScores / 3;
Console.WriteLine("Сумма баллов: {0:0.00} \nСредняя оценка: {1:0.00}", sumScores, averageScore);
