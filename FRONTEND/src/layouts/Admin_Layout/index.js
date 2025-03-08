import React from "react";
import Sidebar from './../../components/Admin/shared/Sidebar';
import { Header } from './../../components/Admin/shared/Header';
import Footer from './../../components/Admin/shared/Footer';
const AdminLayout = ({children}) => {
    return (
        <div className="flex flex-row bg-neutral-100 h-screen w-screen overflow-hidden">
            <div><Sidebar /></div>
            <div className="p-1 flex-col overflow-auto">
                <div><Header /></div>
                <div>{children}</div>
                <div><Footer /></div>
            </div>

        </div>
    )
}

export default AdminLayout;