USE Hotel
GO

INSERT INTO Rooms (Number, How_many_persons, Size, Price, Available) VALUES
 ('1', '2', '20', '100', '1'),
 ('2', '2', '25', '150', '0'),
 ('3', '1', '20', '120', '0'),
 ('4', '1', '25', '170', '0');

INSERT INTO Treatments (Name, Price, Duration, Description,	Active) VALUES
 ('Body Masage', '130', '60', 'Combination of massage techniques to destresses the mind and the body. Designed to ease muscle tension and to alleviate aches and pains.', '1'),
 ('Gold Treatment', '230', '90', 'An exotic exfoliation ritual to leave the skin glowing and hydrated. A golden elixir cleansing foot ritual prepares you for your journey.', '1'),
 ('Elemis Clarity Facial', '80', '30', 'This introductory facial provides a quick and instant pick-me-up for any occasion.', '1'),
 ('Express Pedicure', '60', '30', 'Sit back and relax while your nails are filed, tided and polished to perfection.', '1'),
 ('EXOTIC LIME AND GINGER SALT GLOW', '260', '30', 'After light body brushing, warm oil is dripped luxuriously over the body, before the sublime Elemis Exotic Lime and Ginger Salt Glow is applied.', '1'),
 ('AROMA STONE THERAPY', '200', '130', 'Small stones are placed on key energy points, whilst luxuriously warmed oils are massaged deeply into the body for maximum relaxation.', '1'),
 ('MOROCCAN ROSE RITUAL', '360', '150', 'Let us indulge you in a REN bespoke facial, scrub and massage; it relieves stress, uplifts and soothes, leaving you with the ultimate feeling of balance, and relaxation.', '1'),
 ('Chocolate Body Wrap', '220', '60', 'Therapy that integrates the aromatic oils of Frangipani and Ylang Ylang and Sea Salts to cleanse and purify leaving skin smooth and soft. A warm layer of chocolate is then applied all over the body.', '1');

INSERT INTO Clients (Name_surname, Id_number, Company, Room_number,	Is_here,Vegetarian, Questionnaire, Invoice) VALUES
 ('Monika Piatek', 'I89JA0', 'Allegro', (SELECT [Id] FROM Rooms WHERE Number=1), 1, 0, 0, 1),
 ('Tomasz Wisi', 'H98W92', 'Samsung', (SELECT [Id] FROM Rooms WHERE Number=3), 0, 1, 1, 1),
 ('Patrycja Klaczek', 'PJ98KJ', 'Google', (SELECT [Id] FROM Rooms WHERE Number=4), 1, 0, 0, 1);

INSERT INTO Clients (Name_surname, Id_number, Room_number,	Is_here,Vegetarian, Questionnaire, Invoice) VALUES
 ('Katarzyna Jak', 'P098IJ', (SELECT [Id] FROM Rooms WHERE Number=4), 1, 0, 0, 0)

 
INSERT INTO TreatmentsHistory(Client_id, Treatment_id, This_stay, Done) VALUES
 ((SELECT [Id] FROM Clients WHERE Name_surname='Monika Piatek'), (SELECT [Id] FROM Treatments WHERE Name='MOROCCAN ROSE RITUAL'), 1, 1),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Monika Piatek'), (SELECT [Id] FROM Treatments WHERE Name='AROMA STONE THERAPY'), 1, 0),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Monika Piatek'), (SELECT [Id] FROM Treatments WHERE Name='Gold Treatment'), 0, 1),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Monika Piatek'), (SELECT [Id] FROM Treatments WHERE Name='EXOTIC LIME AND GINGER SALT GLOW'), 0, 1),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Tomasz Wisi'), (SELECT [Id] FROM Treatments WHERE Name='Body Masage'), 1, 1),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Tomasz Wisi'), (SELECT [Id] FROM Treatments WHERE Name='Chocolate Body Wrap'), 1, 0),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Tomasz Wisi'), (SELECT [Id] FROM Treatments WHERE Name='Elemis Clarity Facial'), 0, 1),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Katarzyna Jak'), (SELECT [Id] FROM Treatments WHERE Name='EXOTIC LIME AND GINGER SALT GLOW'), 1, 0),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Katarzyna Jak'), (SELECT [Id] FROM Treatments WHERE Name='Express Pedicure'), 1, 0),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Katarzyna Jak'), (SELECT [Id] FROM Treatments WHERE Name='Elemis Clarity Facial'), 1, 1),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Patrycja Klaczek'), (SELECT [Id] FROM Treatments WHERE Name='MOROCCAN ROSE RITUAL'), 0, 1),
 ((SELECT [Id] FROM Clients WHERE Name_surname='Patrycja Klaczek'), (SELECT [Id] FROM Treatments WHERE Name='Chocolate Body Wrap'), 0, 0);
