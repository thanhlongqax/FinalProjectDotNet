import ForgotPassword from "../components/ForgotPassword";
import Login from "../components/Login";
import Newsletter from "../components/Newsletter";
import { AdminLayout, DefaultLayout } from "../layouts"; 
import {ProductLayout } from "../layouts";
import {NoLayout } from "../layouts";
import {AuthsLayout } from "../layouts";
import {DetailsLayout } from "../layouts";
import HomeLayout from "../layouts/HomeLayout";
import AboutUs from './../components/AboutUs';
import Team from './../components/Team';
import Dishes from "../components/Dishes";
import Reservation from "../components/Reservation";
import Dashboard from './../components/Admin/Dashboard';
import { Products } from './../components/Admin/Products';
import Emloyee from "../components/Admin/Emloyee";
import Category from "../components/Admin/Category";
import { Booking } from './../components/Admin/Booking';
import { User } from './../components/Admin/User';
import AddProducts from './../components/Admin/AddProducts';
import AddEmloyee from './../components/Admin/AddEmloyee';
import AddCategory from "../components/Admin/AddCategory";
import AddBooking from './../components/Admin/AddBooking';
import AddUser from './../components/Admin/AddUser';
import EditProducts from "../components/Admin/EditProduct";
import EditEmloyee from './../components/Admin/EditEmployee';
import EditCategory from './../components/Admin/EditCategory';
import EditBooking from './../components/Admin/EditBooking';
import EditUser from "../components/Admin/EditUser";
//public Route
const publicRoute = [
    { path: '/', component: HomeLayout , layout:HomeLayout },
    { path: 'Gimji', component: HomeLayout , layout:HomeLayout },
    { path: 'dang-nhap', component: Login , layout:AuthsLayout },
    { path: 'quen-mat-khau', component: ForgotPassword , layout:AuthsLayout},
    { path: 'Gimji', component: HomeLayout , layout:HomeLayout },
    {path : 've-chung-toi' , component: AboutUs , layout : DefaultLayout},
    {path : 'thuc-don' , component: Dishes , layout : ProductLayout  ,       
        children: [
            // Cấu hình route con cho trang chính
            { path: ':id', component: Dishes, layout: ProductLayout }
        ]
    },
    { path: 'chi-tiet/:id', component: DetailsLayout, layout: DetailsLayout },
    {path : 'doi-ngu-dau-bep' , component: Team , layout : DefaultLayout},
    {path : 'dat-ban' , component: Reservation, layout : DefaultLayout},
    {path : 'lien-he' , component: Newsletter , layout : DefaultLayout},
    { path: '*', component:NoLayout, layout: NoLayout  },
    {path : 'admin/dashboard', component:Dashboard , layout: AdminLayout},
    {path : 'admin/san-pham' ,component:Products , layout:AdminLayout},
    {path: 'admin/san-pham/edit/:productID', component: EditProducts, layout: AdminLayout },
    {path : 'admin/them-san-pham' ,component:AddProducts, layout:AdminLayout},
    {path : 'admin/nhan-vien' ,component:Emloyee, layout:AdminLayout},
    {path: 'admin/nhan-vien/edit/:id', component: EditEmloyee, layout: AdminLayout },
    {path : 'admin/them-nhan-vien' ,component:AddEmloyee, layout:AdminLayout},
    {path : 'admin/danh-muc' ,component:Category , layout:AdminLayout},
    {path : 'admin/them-danh-muc' ,component:AddCategory , layout:AdminLayout},
    {path: 'admin/danh-muc/edit/:id', component: EditCategory, layout: AdminLayout },
    {path : 'admin/dat-ban' ,component:Booking , layout:AdminLayout},
    {path : 'admin/them-dat-ban' ,component:AddBooking, layout:AdminLayout},
    {path: 'admin/dat-ban/edit/:id', component: EditBooking, layout: AdminLayout },
    {path : 'admin/khach-hang' ,component:User , layout:AdminLayout},
    {path : 'admin/them-khach-hang' ,component:AddUser , layout:AdminLayout},
    {path: 'admin/khach-hang/edit/:id', component: EditUser, layout: AdminLayout }

];
//private Route 
const privateRoute =[];
export {privateRoute, publicRoute}