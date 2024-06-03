import {
    Typography,
    Card,
} from "@material-tailwind/react";


export default function EditBooking() {
    return (
        <Card className="h-full w-full mt-3 ">
            <form>
                <div className="space-y-12 ">
                    <div className="border-b border-gray-900/10 pb-12 px-10">
                        <div className="flex flex-col lg:flex-row items-center justify-between gap-8">
                            <div className="pt-8">
                                <Typography variant="h5" color="blue-gray">
                                    Đặt bàn
                                </Typography>
                                <Typography color="gray" className="mt-1 font-normal">
                                    Chỉnh sửa đặt bàn trước
                                </Typography>
                            </div>
                        </div>

                        <div className="mt-5 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                            <div className=" sm:col-span-5">
                                <div className="mt-10 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                                    <div className="sm:col-span-3">
                                        <label htmlFor="name" className="block text-l font-semibold leading-6 text-gray-900">
                                            Tên khách hàng
                                        </label>
                                        <div className="mt-2">
                                            <input
                                                type="text"
                                                name="name"
                                                id="name"
                                                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                                placeholder='Tên khách hàng'
                                            />
                                        </div>
                                    </div>
                                    <div className="sm:col-span-3">
                                        <label htmlFor="time" className="block text-l font-semibold leading-6 text-gray-900">
                                            Thời gian đặt bàn
                                        </label>
                                        <div className="mt-2">
                                            <input
                                                type="datetime-local"
                                                name="time"
                                                id="time"
                                                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                            />
                                        </div>
                                    </div>
                                </div>
                                <div className="mt-5 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                                    <div className="sm:col-span-3">
                                        <label htmlFor="starttime" className="block text-l font-semibold leading-6 text-gray-900">
                                            Thời gian bắt đầu
                                        </label>
                                        <div className="mt-2">
                                            <input
                                                type="datetime-local"
                                                name="starttime"
                                                id="starttime"
                                                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                            />
                                        </div>
                                    </div>
                                    <div className="sm:col-span-3">
                                        <label htmlFor="partysize" className="block text-lg font-semibold leading-6 text-gray-900">
                                            Party Size
                                        </label>
                                        <div className="mt-2">
                                            <input
                                                type="number"
                                                name="partysize"
                                                id="partysize"
                                                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                            />
                                        </div>
                                    </div>
                                </div>
                                <div className="col-span-full mt-5">
                                    <label htmlFor="reservationStatus" className="block text-lg font-semibold leading-6 text-gray-900">
                                        Trạng thái
                                    </label>
                                    <div className="mt-2">
                                        <select
                                            id="reservationStatus"
                                            name="reservationStatus"
                                            autoComplete="reservationStatus"
                                            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 focus:ring-2 focus:ring-inset focus:ring-indigo-600  sm:text-sm sm:leading-6"
                                        >
                                            <option>Thành công</option>
                                            <option>Thất bại</option>
                                        </select>
                                    </div>
                                </div>
                                <div className="col-span-full mt-5">
                                    <label htmlFor="emloyee" className="block text-lg font-semibold leading-6 text-gray-900">
                                        Nhân viên nhận đặt bàn
                                    </label>
                                    <div className="mt-2">
                                        <input
                                            type="text"
                                            name="emloyee"
                                            id="emloyee"
                                            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                            placeholder='Tên nhân viên'
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
