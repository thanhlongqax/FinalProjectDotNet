import { PhotoIcon } from '@heroicons/react/solid';
import {
    Typography,
    Card,
} from "@material-tailwind/react";
import { CkEditor } from './CkEditor';


export default function AddCategory() {
    return (
        <Card className="h-full w-full mt-3 ">
            <form>
                <div className="space-y-12 ">
                    <div className="border-b border-gray-900/10 pb-12 px-10">
                        <div className="flex flex-col lg:flex-row items-center justify-between gap-8">
                            <div className="pt-8">
                                <Typography variant="h5" color="blue-gray">
                                    Danh mục
                                </Typography>
                                <Typography color="gray" className="mt-1 font-normal">
                                    Thêm mới danh mục
                                </Typography>
                            </div>
                        </div>

                        <div className="mt-5 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                            <div className=" sm:col-span-5">
                                <div className="mt-10 grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                                    <div className="sm:col-span-3">
                                        <label htmlFor="name" className="block text-l font-semibold leading-6 text-gray-900">
                                            Tên danh mục
                                        </label>
                                        <div className="mt-2">
                                            <input
                                                type="text"
                                                name="name"
                                                id="name"
                                                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                                placeholder='Tên danh mục'
                                            />
                                        </div>
                                    </div>
                                </div>
                                <div className="col-span-full mt-5">
                                    <label htmlFor="about" className="block text-lg font-semibold  leading-6 text-gray-900">
                                        Mô tả
                                    </label>
                                    <CkEditor/>
                                </div>

                                <div className="col-span-full">
                                    <label htmlFor="meta" className="block text-lg font-semibold leading-6 text-gray-900">
                                        Meta
                                    </label>
                                    <div className="mt-2">
                                        <input
                                            type="text"
                                            name="meta"
                                            id="meta"
                                            className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
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
