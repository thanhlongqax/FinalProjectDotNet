import React from "react";
import { Link } from "react-router-dom";
import logo from "../../../assets/img/header/logo-white.png";
import {
  Card,
  Typography,
  List,
  ListItem,
  ListItemPrefix,
} from "@material-tailwind/react";
import {
  PresentationChartBarIcon,
  ShoppingBagIcon,
  UserCircleIcon,
  Cog6ToothIcon,
  InboxIcon,
  PowerIcon,
  ClipboardDocumentListIcon,
  UserGroupIcon,
} from "@heroicons/react/24/solid";

const Sidebar = () => {
  const [open, setOpen] = React.useState(0);

  const handleOpen = (value) => {
    setOpen(open === value ? 0 : value);
  };

  return (
    <Card className=" h-screen w-full max-w-[10rem] lg:max-w-[30rem] p-4 shadow-xl shadow-blue-gray-900/5 flex flex-col">
      <div className="mb-2 p-4">
        <img
          src={logo}
          alt="Company Logo"
          style={{ width: "100px", height: "auto" }}
        />
      </div>

      <List>
        {/* <Accordion
                    open={open === 1}
                    icon={
                        <ChevronDownIcon
                            strokeWidth={2.5}
                            className={`mx-auto h-4 w-4 transition-transform ${open === 1 ? "rotate-180" : ""}`}
                        />
                    }
                > */}
        <Link to="/admin/dashboard">
          <ListItem>
            <ListItemPrefix>
              <PresentationChartBarIcon className="h-5 w-5" />
            </ListItemPrefix>
            Dashboard
          </ListItem>
        </Link>
        <Link to="/admin/san-pham">
          <ListItem>
            <ListItemPrefix>
              <ShoppingBagIcon className="h-5 w-5" />
            </ListItemPrefix>
            Sản phẩm
          </ListItem>
        </Link>
        <Link to="/admin/danh-muc">
          <ListItem>
            <ListItemPrefix>
              <InboxIcon className="h-5 w-5" />
            </ListItemPrefix>
            Danh mục
          </ListItem>
        </Link>

        <Link to="/admin/nhan-vien">
          <ListItem>
            <ListItemPrefix>
              <UserCircleIcon className="h-5 w-5" />
            </ListItemPrefix>
            Nhân viên
          </ListItem>
        </Link>
        <Link to="/admin/khach-hang">
          <ListItem>
            <ListItemPrefix>
              <UserGroupIcon className="h-5 w-5" />
            </ListItemPrefix>
            Khách hàng
          </ListItem>
        </Link>
        <Link to="/admin/dat-ban">
          <ListItem>
            <ListItemPrefix>
              <ClipboardDocumentListIcon className="h-5 w-5" />
            </ListItemPrefix>
            Đặt bàn
          </ListItem>
        </Link>
        <ListItem>
          <ListItemPrefix>
            <Cog6ToothIcon className="h-5 w-5" />
          </ListItemPrefix>
          Cài đặt
        </ListItem>
        <ListItem>
          <ListItemPrefix>
            <PowerIcon className="h-5 w-5" />
          </ListItemPrefix>
          Đăng xuất
        </ListItem>
      </List>
    </Card>
  );
};

export default Sidebar;
