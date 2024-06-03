import {
  MagnifyingGlassIcon,
  ChevronUpDownIcon,
  PlusIcon,
} from "@heroicons/react/24/outline";
import { PencilIcon, UserPlusIcon } from "@heroicons/react/24/solid";
import { Select, Option } from "@material-tailwind/react";
import {
  Card,
  CardHeader,
  Input,
  Typography,
  Button,
  CardBody,
  IconButton,
  Tooltip,
} from "@material-tailwind/react";
import React, { useState, useEffect, useCallback } from "react";
import { Link, useParams } from "react-router-dom";
import productService from "../../services/ProductService";
import queryString from "query-string";
import Pagination from "../Admin/Paignation";
import { TrashIcon } from "@heroicons/react/24/solid";
import categoryService from "./../../services/CategoryService";

const TABLE_HEAD = [
  "Id",
  "Tên sản phẩm",
  "Hình đại diện",
  "Hình 2",
  "Hình 3",
  "Mô tả",
  "Giá",
  "Nsn",
  "Danh mục",
  "Sửa",
  "Xóa",
];

const TABLE_ROWS = [
  {
    id: "1",
    name: "Kimbab",
    image1: "",
    image2: "",
    image3: "",
    description: "Cơm, rong biển ",
    price: "65,000",
    nsn: "text",
    directory: "Kimbab",
    edit: "",
  },
];

export function Products() {
  const { id } = useParams();
  const [products, setProducts] = useState([]);
  const [categories, setCategory] = useState([]);
  const [pagination, setPagination] = useState({
    page: 1,
    limit: 6,
    totalRows: 1,
  });
  const [filter, setFilter] = useState({
    limit: 6,
    page: 1,
    id: id,
  });

  function handlePageChange(newPage) {
    setFilter({
      ...filter,
      page: newPage,
    });
  }
  // Sử dụng useEffect để theo dõi thay đổi của id từ useParams() và cập nhật filter tương ứng
  useEffect(() => {
    setFilter((prevFilter) => ({
      ...prevFilter,
      id: id, // Cập nhật id trong filter với giá trị mới từ useParams()
    }));
  }, [id]);
  async function getProductAll(filter) {
    const paramsString = queryString.stringify(filter);
    const res = await productService.getProductAll(paramsString);
    setProducts(res);
    setPagination(filter);
  }
  async function getCategoryAll() {
    const res = await categoryService.getCategoryAll();
    setCategory(res);
  }
  async function getProductByCategory(categoryCode, filter) {
    const paramsString = queryString.stringify(filter);
    const res = await productService.getProductByCategory(
      categoryCode,
      paramsString
    );
    setProducts(res);
    setPagination(filter);
  }
  const handleDelete = useCallback(async (productID) => {
    try {
      // Thực hiện xóa sản phẩm
      await productService.deleteProduct(productID);
      // Xử lý sau khi xóa thành công, ví dụ như cập nhật danh sách sản phẩm
      console.log("Product deleted successfully");
    } catch (error) {
      console.error("Error deleting product:", error);
    }
  }, []);
  useEffect(() => {
    if (id == null) {
      getProductAll(filter);
    } else if (id == "tat-ca-mon-an") {
      getProductAll(filter);
    } else {
      getProductByCategory(id, filter);
    }
  }, [filter, handleDelete]);
  useEffect(() => {
    getCategoryAll();
  }, []);
  return (
    <Card className="h-full w-full mt-3">
      <CardHeader floated={false} shadow={false} className="rounded-none">
        <div className="mb-8 flex flex-col lg:flex-row items-center justify-between gap-8">
          <div className="pt-2">
            <Typography variant="h5" color="blue-gray">
              Sản phẩm
            </Typography>
            <Typography color="gray" className="mt-1 font-normal">
              Các sản phẩm đang kinh doanh
            </Typography>
          </div>
          <div className="flex shrink-0 flex-col gap-2 sm:flex-row">
            <div className="w-72" >
              <Select color="red" label="--Chọn danh mục--">
                {categories.map((category) => (
                  <Option key={category.codeValue}>{category.name}</Option>
                ))}
              </Select>
            </div>

            <Link to="/admin/them-san-pham">
              <Button className="flex items-center bg-accent gap-3" size="sm">
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
      <CardBody className="overflow-auto h-[450px] px-0">
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
            {products.map(
              (
                {
                  productID,
                  name,
                  image1,
                  image2,
                  image3,
                  description,
                  price,
                  nsn,
                  category,
                  edit,
                },
                index
              ) => {
                const isLast = index === TABLE_ROWS.length - 1;
                const classes = isLast
                  ? "p-4"
                  : "p-4 border-b border-blue-gray-50";
                return (
                  <tr key={productID}>
                    <td className="p-4 border-b border-blue-gray-50">
                      <div className="flex flex-col">
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          {productID}
                        </Typography>
                      </div>
                    </td>
                    <td className="p-4 border-b border-blue-gray-50">
                      <div className="flex items-center gap-3">
                        <div className="flex flex-col">
                          <Typography
                            variant="small"
                            color="blue-gray"
                            className="font-normal"
                          >
                            {name}
                          </Typography>
                        </div>
                      </div>
                    </td>
                    <td className="p-4 border-b border-blue-gray-50">
                      <div className="flex flex-col">
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          {image1}
                        </Typography>
                      </div>
                    </td>
                    <td className="p-4 border-b border-blue-gray-50">
                      <div className="flex flex-col">
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          {image2}
                        </Typography>
                      </div>
                    </td>
                    <td className={classes}>
                      <div className="flex flex-col">
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          {image3}
                        </Typography>
                      </div>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {description}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <div className="w-max">
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          {price}
                        </Typography>
                      </div>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {nsn}
                      </Typography>
                    </td>

                    <td className={classes}>
                      <div className="w-max">
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          {category.codeValue}
                        </Typography>
                      </div>
                    </td>
                    <td className="p-4 border-b border-blue-gray-50">
                      <Tooltip content="Edit">
                        {/* Sử dụng Link để tạo liên kết */}
                        <Link to={`/admin/san-pham/edit/${productID}`}>
                          <IconButton variant="text">
                            <PencilIcon className="h-4 w-4" />
                          </IconButton>
                        </Link>
                      </Tooltip>
                    </td>
                    <td className="p-4 border-b border-blue-gray-50">
                      <Tooltip content="Delete">
                        <IconButton
                          variant="text"
                          onClick={() => handleDelete(productID)}
                        >
                          <TrashIcon className="h-4 w-4" />
                        </IconButton>
                      </Tooltip>
                    </td>
                  </tr>
                );
              }
            )}
          </tbody>
        </table>
      </CardBody>
      <Pagination pagination={pagination} onPageChange={handlePageChange} />
    </Card>
  );
}

export default Products;
