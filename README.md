# 🏨 Hotel Booking System - ASP.NET Web Forms

## Project Information
**Course:** COCS 307 - Programming III  
**Project Type:** ASP.NET Web Forms Application  
**Team Name:** Code Crafters  

## Team Members
1. **Haya Alharbi** (2307568) - M1: Authentication & User Management
2. **Jana Alharbi** (2305762) - M2: Booking Creation & Management
3. **Mayar Mahfouz** (2306450) - M3: Room Management & Pricing
4. **Shahad Alamoudi** (2309063) - M4: Notifications & Error Handling
5. **Shahad Abdullah** (2207358) - M5: UI/UX Design & Testing

## Project Description
A comprehensive hotel booking management system that allows guests to book rooms with dynamic pricing, and administrators to manage rooms, bookings, and guest services.

## Features Implemented
1. ✅ User Authentication (Admin/Guest roles)
2. ✅ Booking Creation with guest details and additional services
3. ✅ Real-time room availability and dynamic pricing
4. ✅ Booking View, Update, and Cancellation with penalties
5. ✅ Booking Status Management (Pending, Confirmed, Checked-In, Checked-Out, Cancelled)
6. ✅ Sorting and Filtering of bookings
7. ✅ Dynamic Room Pricing (seasonality, promotions, length-of-stay)
8. ✅ Room Management (Admin only)
9. ✅ Email Notification System
10. ✅ Booking Comments (Admin)
11. ✅ Comprehensive Error Handling
12. ✅ Responsive Bootstrap UI

## Technology Stack
- **Framework:** ASP.NET Web Forms (.NET Framework 4.8)
- **Language:** C# 7.3
- **UI Framework:** Bootstrap 5.3
- **Data Storage:** In-memory Collections (List<T>, Dictionary)
- **IDE:** Visual Studio 2022

## Project Structure
```
HotelBookingSystem/
├── App_Code/
│   ├── Models/
│   │   ├── User.cs
│   │   ├── Room.cs
│   │   ├── Booking.cs
│   │   ├── Service.cs
│   │   └── Notification.cs
│   ├── Enums/
│   │   ├── BookingStatus.cs
│   │   ├── RoomType.cs
│   │   └── UserRole.cs
│   ├── Managers/
│   │   ├── DataManager.cs
│   │   ├── BookingManager.cs
│   │   ├── RoomManager.cs
│   │   └── NotificationManager.cs
│   └── Utilities/
│       ├── PricingEngine.cs
│       └── ValidationHelper.cs
├── Pages/
│   ├── Login.aspx
│   ├── Dashboard.aspx
│   ├── CreateBooking.aspx
│   ├── BookingDetails.aspx
│   ├── AdminDashboard.aspx
│   └── RoomManagement.aspx
├── MasterPages/
│   ├── Site.Master
│   └── Admin.Master
├── Content/
│   ├── css/
│   └── images/
└── Web.config
```

## How to Run
1. Open `HotelBookingSystem.sln` in Visual Studio 2022
2. Restore NuGet packages (if any)
3. Build the solution (Ctrl+Shift+B)
4. Run the project (F5)
5. Use default credentials:
   - **Admin:** admin@hotel.com / Admin123
   - **Guest:** guest@hotel.com / Guest123

## Default Test Accounts
| Email | Password | Role |
|-------|----------|------|
| admin@hotel.com | Admin123 | Admin |
| halharbi0568@stu.kau.edu.sa | Haya123 | Guest |
| jalharbi0143@stu.kau.edu.sa | Jana123 | Guest |
| mmahfouz0007@stu.kau.edu.sa | Mayar123 | Guest |
| salamoudi0191@stu.kau.edu.sa | Shahad1 | Guest |
| salsubhi0115@stu.kau.edu.sa | Shahad2 | Guest |

## Key Functionalities

### Guest Features
- Create new bookings with room selection
- View personal booking history
- Update booking details
- Cancel bookings (with penalty calculation)
- Filter/sort bookings by date, status, room type
- Select additional services (spa, meals, transport)

### Admin Features
- View all bookings across the system
- Update booking status
- Add internal comments to bookings
- Manage room inventory (add/edit/delete)
- Set dynamic pricing rules
- Mark rooms as unavailable for maintenance
- Send notifications to guests

### Dynamic Pricing Factors
- Room type (Standard: $100, Deluxe: $200, Suite: $350)
- Season (Peak: +50%, Off-peak: -20%)
- Length of stay (7+ days: -15%, 30+ days: -25%)
- Early bird discount (30+ days advance: -10%)
- Last-minute deals (Within 48 hours: -30%)

### Cancellation Policy
- Free cancellation: Within 24 hours of booking
- 50% penalty: 24-48 hours after booking
- 100% penalty: After 48 hours

## Testing
Refer to `TestCases.docx` for comprehensive test scenarios.

## Documentation
- **Code Documentation:** Inline comments throughout the codebase
- **Project Report:** See `ProjectReport.docx`
- **Presentation:** See `TeamPresentation.pptx`

## Academic Integrity
This project was developed as part of COCS 307 coursework. All code is original and developed by team members listed above.

---
**Last Updated:** October 2025  
**Version:** 1.0.0
