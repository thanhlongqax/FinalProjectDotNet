import { Typography } from "@material-tailwind/react";

export default function Footer() {
    return (
        <footer className="flex w-full flex-row flex-wrap items-center border-t border-blue-gray-50 py-4 text-center md:justify-between">
            <Typography color="blue-gray" className="font-normal text-center">
                &copy; 2024 Nhà hàng hàn quốc Gimji
            </Typography>

        </footer>
    );
}
