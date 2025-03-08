import {
    Typography,
    Card,
} from "@material-tailwind/react";


export default function AddEmloyee() {
    return (
        <Card className="h-full w-full mt-3 ">
            <form>
                <div className="space-y-12 ">
                    <div className="border-b border-gray-900/10 pb-12 px-10">
                        <div className="flex flex-col lg:flex-row items-center justify-between gap-8">
                            <div className="pt-8">
                                <Typography variant="h5" color="blue-gray">
                                    Nhân viên
                                </Typography>
                                <Typography color="gray" className="mt-1 font-normal">
                                    Thêm mới nhân viên
                                </Typography>
                            </div>
                        </div>

                        <div className="mt-5 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                            <div className=" sm:col-span-5">
                                <div className="mt-10 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                                    <div className="sm:col-span-3">
                                        <label htmlFor="name" className="block text-l font-semibold leading-6 text-gray-900">
                                            Tên nhân viên
                                        </label>
                                        <div className="mt-2">
                                            <input
                                                type="text"
                                                name="name"
                                                id="name"
                                                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                                placeholder='Tên nhân viên'
                                            />
                                        </div>
                                    </div>
                                    <div className="sm:col-span-3">
                                        <label htmlFor="birth" className="block text-l font-semibold leading-6 text-gray-900">
                                            Ngày sinh
                                        </label>
                                        <div className="mt-2">
                                            <input
                                                type="date"
                                                name="birth"
                                                id="birth"
                                                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                            />
                                        </div>
                                    </div>
                                </div>
                                <div className="mt-5 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                                    <div className="sm:col-span-3">
                                        <label htmlFor="gender" className="block text-lg font-semibold leading-6 text-gray-900">
                                            Giới tính
                                        </label>
                                        <div className="mt-2">
                                            <select
                                                id="gender"
                                                name="gender"
                                                autoComplete="gender"
                                                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 focus:ring-2 focus:ring-inset focus:ring-indigo-600  sm:text-sm sm:leading-6"
                                            >
                                                <option>Nam</option>
                                                <option>Nữ</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div className="sm:col-span-3">
                                        <label htmlFor="phone" className="block text-lg font-semibold leading-6 text-gray-900">
                                            Số điện thoại
                                        </label>
                                        <div className="mt-2">
                                            <input
                                                type="text"
                                                name="phone"
                                                id="phone"
                                                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                                placeholder='Số điện thoại'
                                            />
                                        </div>
                                    </div>
                                </div>
                                <div className="sm:col-span-4 mt-5">
                                    <label htmlFor="email" className="block text-lg font-semibold leading-6 text-gray-900">
                                        Email
                                    </label>
                                    <div className="mt-2">
                                        <input
                                            id="email"
                                            name="email"
                                            type="email"
                                            autoComplete="email"
                                            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                            placeholder='Email'
                                        />
                                    </div>
                                </div>
                                <div className="col-span-full mt-5">
                                    <label htmlFor="address" className="block text-lg font-semibold leading-6 text-gray-900">
                                        Địa chỉ
                                    </label>
                                    <div className="mt-2">
                                        <input
                                            type="text"
                                            name="address"
                                            id="address"
                                            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                            placeholder='Địa chỉ'
                                        />
                                    </div>
                                </div>
                                <div className="col-span-full mt-5">
                                    <label htmlFor="jobtitle" className="block text-lg font-semibold leading-6 text-gray-900">
                                        Vị trí
                                    </label>
                                    <div className="mt-2">
                                        <input
                                            type="text"
                                            name="jobtitle"
                                            id="jobtitle"
                                            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                            placeholder='Vị trí'
                                        />
                                    </div>
                                </div>


                            </div>
                        </div>


                    </div>

                    <div className="mt-6 flex items-center justify-end gap-x-6">
                        <button type="button" className=" rounded-md px-3 py-2 text-sm font-semibold leading-6 text-gray-900 hover:bg-accent-hover">
                            Hủy
                        </button>
                        <button
                            type="submit"
                            className="rounded-md bg-accent px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-accent-hover focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                        >
                            Lưu
                        </button>
                    </div>
                </div>
            </form>
        </Card>
    )
}
