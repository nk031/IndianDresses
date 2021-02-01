SET IDENTITY_INSERT [dbo].[RegularClient] ON
INSERT INTO [dbo].[RegularClient] ([ClientID], [ClientName], [ClientEmail], [Mobile], [Purpose], [ArriveDate]) VALUES (1, N'Rosie', N'Rosie@gmail.com', N'0202116789', N'Buy Kurtee', N'2021-01-14 00:00:00')
INSERT INTO [dbo].[RegularClient] ([ClientID], [ClientName], [ClientEmail], [Mobile], [Purpose], [ArriveDate]) VALUES (2, N'Harsha Prasal', N'Harsha@luca.kiwi', N'0213456789', N'Pure crape lehengha buy', N'2021-01-14 00:00:00')
INSERT INTO [dbo].[RegularClient] ([ClientID], [ClientName], [ClientEmail], [Mobile], [Purpose], [ArriveDate]) VALUES (3, N'Cerole', N'Caroway029@gmail.com', N'021025783336', N'Saree buy', N'2021-01-11 00:00:00')
INSERT INTO [dbo].[RegularClient] ([ClientID], [ClientName], [ClientEmail], [Mobile], [Purpose], [ArriveDate]) VALUES (4, N'Roshni', N'Roshnimm3@gmail.com', N'0212305678', N'Frock style buy', N'2020-12-16 00:00:00')
INSERT INTO [dbo].[RegularClient] ([ClientID], [ClientName], [ClientEmail], [Mobile], [Purpose], [ArriveDate]) VALUES (5, N'Helan', N'Helen78@gmail.com', N'0232445667', N'Book order', N'2021-01-05 00:00:00')
SET IDENTITY_INSERT [dbo].[RegularClient] OFF


SET IDENTITY_INSERT [dbo].[OurEmployee] ON
INSERT INTO [dbo].[OurEmployee] ([EmployeeID], [EmployeeName], [Address], [MobileNumber], [ShiftStart], [ShiftFinish]) VALUES (1, N'Akshita', N'Ulster street Whitiora', N'0223456757', N'2021-01-27 11:00:00', N'2021-01-27 17:00:00')
INSERT INTO [dbo].[OurEmployee] ([EmployeeID], [EmployeeName], [Address], [MobileNumber], [ShiftStart], [ShiftFinish]) VALUES (2, N'Rose Mary', N'72 Memorial Drive', N'0234456689', N'2021-01-27 09:01:00', N'2021-01-27 16:01:00')
INSERT INTO [dbo].[OurEmployee] ([EmployeeID], [EmployeeName], [Address], [MobileNumber], [ShiftStart], [ShiftFinish]) VALUES (3, N'Sanah', N'55 maitland street', N'0221232323', N'2021-01-27 10:00:00', N'2021-01-27 16:00:00')
INSERT INTO [dbo].[OurEmployee] ([EmployeeID], [EmployeeName], [Address], [MobileNumber], [ShiftStart], [ShiftFinish]) VALUES (4, N'Nusrat', N'45 LakeSide', N'0213456789', N'2021-01-27 11:30:00', N'2021-01-27 17:00:00')
SET IDENTITY_INSERT [dbo].[OurEmployee] OFF

SET IDENTITY_INSERT [dbo].[OnlineSale] ON
INSERT INTO [dbo].[OnlineSale] ([ID], [ClientID], [StockID]) VALUES (1, 5, 1)
INSERT INTO [dbo].[OnlineSale] ([ID], [ClientID], [StockID]) VALUES (2, 1, 2)
INSERT INTO [dbo].[OnlineSale] ([ID], [ClientID], [StockID]) VALUES (3, 2, 7)
INSERT INTO [dbo].[OnlineSale] ([ID], [ClientID], [StockID]) VALUES (4, 3, 4)
INSERT INTO [dbo].[OnlineSale] ([ID], [ClientID], [StockID]) VALUES (5, 4, 6)
INSERT INTO [dbo].[OnlineSale] ([ID], [ClientID], [StockID]) VALUES (6, 5, 5)
SET IDENTITY_INSERT [dbo].[OnlineSale] OFF


SET IDENTITY_INSERT [dbo].[AvalibleStock] ON
INSERT INTO [dbo].[AvalibleStock] ([StockID], [Category], [Price], [AvalibleSize]) VALUES (1, N'Evening Gown IN-07', N'$ 119', N'XXL')
INSERT INTO [dbo].[AvalibleStock] ([StockID], [Category], [Price], [AvalibleSize]) VALUES (2, N'Stiched Lehengha', N'$ 211', N'Medium')
INSERT INTO [dbo].[AvalibleStock] ([StockID], [Category], [Price], [AvalibleSize]) VALUES (3, N'Casual Wear -19', N'$ 65', N'Small')
INSERT INTO [dbo].[AvalibleStock] ([StockID], [Category], [Price], [AvalibleSize]) VALUES (4, N'Designer Suit', N'$ 180', N'Large')
INSERT INTO [dbo].[AvalibleStock] ([StockID], [Category], [Price], [AvalibleSize]) VALUES (5, N'Frock Style -PK003', N'$ 220', N'XXL')
INSERT INTO [dbo].[AvalibleStock] ([StockID], [Category], [Price], [AvalibleSize]) VALUES (6, N'Patiala Suit', N'$ 140', N'Medium')
INSERT INTO [dbo].[AvalibleStock] ([StockID], [Category], [Price], [AvalibleSize]) VALUES (7, N'Kurti 007', N'$ 55', N'Small')
INSERT INTO [dbo].[AvalibleStock] ([StockID], [Category], [Price], [AvalibleSize]) VALUES (8, N'Saree -S4', N'$ 120', N'Large')
SET IDENTITY_INSERT [dbo].[AvalibleStock] OFF
