CREATE TABLE Users
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    TestDate DATETIME NULL,
    Score INT NULL,
    TimeSpent INT NULL,
    IsCompleted BIT DEFAULT 0
);

CREATE TABLE Questions
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    QuestionText NVARCHAR(500) NOT NULL,
    Option1 NVARCHAR(200) NOT NULL,
    Option2 NVARCHAR(200) NOT NULL,
    Option3 NVARCHAR(200) NOT NULL,
    Option4 NVARCHAR(200) NOT NULL,
    CorrectAnswer INT NOT NULL,
    QuestionOrder INT NOT NULL
);

CREATE TABLE UserAnswers
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    QuestionId INT NOT NULL,
    SelectedAnswer INT NOT NULL,
    IsCorrect BIT NOT NULL,
    AnswerTime INT NOT NULL,

    CONSTRAINT FK_UserAnswers_User
    FOREIGN KEY (UserId) REFERENCES Users(Id),

    CONSTRAINT FK_UserAnswers_Question
    FOREIGN KEY (QuestionId) REFERENCES Questions(Id)
);

INSERT INTO Questions 
(QuestionText, Option1, Option2, Option3, Option4, CorrectAnswer, QuestionOrder)
VALUES
('Какой символ используется для окончания инструкции в C#?', '.', ';', ':', ',', 2, 1),
('Какой тип данных используется для хранения дробных чисел?', 'int', 'bool', 'double', 'char', 3, 2),
('Какой оператор используется для проверки условий?', 'if', 'for', 'break', 'goto', 1, 3),
('Что делает оператор else?', 'Завершает программу', 'Выполняет альтернативный блок кода', 'Объявляет переменную', 'Создаёт цикл', 2, 4),
('Какой цикл используется, когда количество повторений заранее известно?', 'while', 'for', 'switch', 'try', 2, 5),
('Как называется основной метод запуска программы?', 'Start()', 'Main()', 'Run()', 'Execute()', 2, 6),
('Какой тип данных хранит логическое значение?', 'int', 'bool', 'float', 'string', 2, 7),
('Какой оператор используется для выбора одного из нескольких вариантов?', 'if', 'switch', 'while', 'for', 2, 8),
('Какой класс используется для вывода текста в консоль?', 'Console', 'TextBox', 'Label', 'MessageBox', 1, 9),
('Как называется окно в Windows Forms приложении?', 'Panel', 'Form', 'Window', 'Dialog', 2, 10),
('Какой элемент используется для ввода текста пользователем?', 'Label', 'Button', 'TextBox', 'PictureBox', 3, 11),
('Какой оператор используется для создания объекта?', 'class', 'object', 'new', 'create', 3, 12),
('Что такое метод в C#?', 'Переменная', 'Блок кода выполняющий действие', 'Тип данных', 'Цикл', 2, 13),
('Какой модификатор делает поле доступным только внутри класса?', 'public', 'private', 'protected', 'internal', 2, 14),
('Как называется обработчик нажатия кнопки в WinForms?', 'ButtonClick', 'ClickEvent', 'ButtonPress', 'Click', 4, 15);