import {
  MagnifyingGlassIcon,
  ChevronUpDownIcon,
  PlusIcon,
} from "@heroicons/react/24/outline";
import { PencilIcon } from "@heroicons/react/24/solid";
import { Link } from "react-router-dom";
import {
  Card,
  CardHeader,
  Input,
  Typography,
  Button,
  CardBody,
  CardFooter,
  IconButton,
  Tooltip,
} from "@material-tailwind/react";
import { useEffect, useState } from "react";
import customerService from "./../../services/CustomerService";

const TABLE_HEAD = [
  "Id",
  "Họ tên",
  "Giới tính",
  "Ngày sinh",
  "Email",
  "Số điện thoại",
  "Địa chỉ",
  "Ghi chú",
  "Sửa",
];

const TABLE_ROWS = [
  {
    id: "1",
    name: "Lê Kiều Anh",
    gender: "Nữ",
    birth: "",
    email: "",
    phone: "",
    address: "",
    note: "",
    edit: "",
  },
  {
    id: "2",
    name: "Nguyễn Lâm Thành Long",
    gender: "Nam",
    birth: "",
    email: "",
    phone: "",
    address: "",
    note: "",
    edit: "",
  },
];

export function User() {
  const [users, setUsers] = useState([]);
  async function getUserAll() {
    const res = await customerService.getCustomerAll();
    setUsers(res);
  }
  useEffect(() => {
    getUserAll();
  }, []);
  return (
    <Card className="h-full w-full mt-3">
      <CardHeader floated={false} shadow={false} className="rounded-none">
        <div className="mb-8 flex flex-col lg:flex-row items-center justify-between gap-8">
          <div className="pt-2">
            <Typography variant="h5" color="blue-gray">
              Khách hàng
            </Typography>
            <Typography color="gray" className="mt-1 font-normal">
              Quản lý các khách hàng
            </Typography>
          </div>
          <div className="flex shrink-0 flex-col gap-2 sm:flex-row">
            <Link to="/admin/them-khach-hang">
              <Button className="flex items-center  red" size="sm">
                <PlusIcon strokeWidth={2} className="h-4 w-4" /> Thêm mới
              </Button>
            </Link>
          </div>
        </div>
        <div className="flex flex-col items-end justify-end gap-4 md:flex-row">
          <div className="w-full md:w-72">
            <Input
              label="Tìm kiếm"
              icon={<MagnifyingGlassIcon className="h-5 w-5" />}
            />
          </div>
        </div>
      </CardHeader>
      <CardBody className="overflow-scroll px-0">
        <table className="mt-4 w-full min-w-max table-auto text-left">
          <thead>
            <tr>
              {TABLE_HEAD.map((head, index) => (
                <th
                  key={head}
                  className="cursor-pointer border-y border-blue-gray-100 bg-blue-gray-50/50 p-4 transition-colors hover:bg-blue-gray-50"
                >
                  <Typography
                    variant="small"
                    color="blue-gray"
                    className="flex items-center justify-between gap-2 font-normal leading-none opacity-70"
                  >
                    {head}{" "}
                    {index !== TABLE_HEAD.length - 1 && (
                      <ChevronUpDownIcon strokeWidth={2} className="h-4 w-4" />
                    )}
                  </Typography>
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {users.map(
              (
                { id, fullName,gender,birthDate,email,telephone,jobTitle,homeLocation,hasCertification,edit},
                index
              ) => {
                const isLast = index === TABLE_ROWS.length - 1;
                const classes = isLast
                  ? "p-4"
                  : "p-4 border-b border-blue-gray-50";

                return (
                  <tr key={id}>
                    <td className={classes}>
                      <div className="flex flex-col">
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          {id}
                        </Typography>
                      </div>
                    </td>
                    <td className={classes}>
                      <div className="flex items-center gap-3">
                        <div className="flex flex-col">
                          <Typography
                            variant="small"
                            color="blue-gray"
                            className="font-normal"
                          >
                            {fullName}
                          </Typography>
                        </div>
                      </div>
                    </td>

                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {gender}
                      </Typography>
                    </td>

                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {birthDate}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {email}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {telephone}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {homeLocation}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {hasCertification}
                      </Typography>
                    </td>

                    <td className="p-4 border-b border-blue-gray-50">
                      <Tooltip content="Edit">
                        {/* Sử dụng Link để tạo liên kết */}
                        <Link to={`/admin/khach-hang/edit/${id}`}>
                          <IconButton variant="text">
                            <PencilIcon className="h-4 w-4" />
                          </IconButton>
                        </Link>
                      </Tooltip>
                    </td>
                  </tr>
                );
              }
            )}
          </tbody>
        </table>
      </CardBody>
      <CardFooter className="flex items-center justify-between border-t border-blue-gray-50 p-4">
        <Typography variant="small" color="blue-gray" className="font-normal">
          Page 1 of 10
        </Typography>
        <div className="flex flex-row gap-2">
          <Button variant="outlined" size="sm">
            Trước
          </Button>
          <div className="flex items-center gap-2">
            <IconButton variant="outlined" size="sm">
              1
            </IconButton>
            <IconButton variant="text" size="sm">
              2
            </IconButton>
            <IconButton variant="text" size="sm">
              3
            </IconButton>
            <IconButton variant="text" size="sm">
              ...
            </IconButton>
            <IconButton variant="text" size="sm">
              8
            </IconButton>
            <IconButton variant="text" size="sm">
              9
            </IconButton>
            <IconButton variant="text" size="sm">
              10
            </IconButton>
          </div>
          <Button variant="outlined" size="sm">
            Sau
          </Button>
        </div>
      </CardFooter>
    </Card>
  );
}

export default User;