
import AdminNav from './AdminNav';
import Link from 'next/link';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import SessionCheck from '../Session';
import { useAuth } from '../AuthContext';

const AdminDashboard = () => {
  const [allHelppost, setAllHelppost] = useState(0);
  const [allUser, setAllUser] = useState(0);
  const [error, setError] = useState('');
  const { user, login, logout, Tkey } = useAuth() || {}; 
  

  useEffect(() => {
    // Fetch products when the component mounts
    GetHelppost();
    GetAllUser();
  }, []);

  const GetHelppost = async () => {
    try {
      const response = await axios.get('https://localhost:44307/api/helppost/GetAllHelpPosts', {
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `${Tkey}`,
        },
      });

      console.log('Response:', response.data);

      // Check for a successful response (HTTP status code 200)
      if (response.data ) {
        console.log('Help Post:', response.data.data);
        setAllHelppost(response.data.length);
      } else {
        console.log('No products available');
        setError('No products available');
      }
    } catch (error) {
      // Log the entire error object for more details
      console.error('Failed:', error);
      setError(`An error occurred trying to fetch products: ${error.message}`);
    }
  };
  const GetAllUser = async () => {
    
      try {
        const response = await axios.get(
          'https://localhost:44307/api/AllUser',
          {
            headers: {
              'Content-Type': 'application/json',
              'Authorization': `${Tkey}`,
            },
          }
        );
         console.log(response.data)
         console.log(response.success)
        if (response.data) {
          console.log('Products:', response.data);
          console.log(response.data);
          setAllUser(response.data.length);
        } else {
          console.log('No products available');
          setError('No products available');
        }
      } catch (error) {
        console.error('Failed:', error);
        setError(`An error occurred trying to fetch products: ${error.message}`);
      }
  };
  return (
    <div>
      <SessionCheck />
  <AdminNav />
  <div className="grid grid-cols-12 pr-6 pl-6 mb-2 mt-0 ">
        <div className="col-span-12 bg-[#dfe4ea] text-[#192a56] shadow-md h-[90vh] ">
      
        <h1 className="text-3xl font-bold mb-4 text-center text-[#192a56]">ADMIN DASHBOARD</h1>
          {/* Upper Section */}
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4 w-full justify-center pr-4 mt-8  pl-4 items-center ml-16">
           
            {/* Card 1 - Total Seller */}
            <div className='bg-[#4fa0b3] text-gray-200 w-[450px] h-40 shadow-md flex flex-col justify-center rounded-sm items-center'>
              <div className='text-5xl font-bold mt-3'>{allUser}</div>
              <div className='text-3xl font-bold'>Total User</div>
              <div className="flex-grow"></div>
              <div className="bg-white w-full h-8 text-gray-600 text-center text-lg font-semibold">
              <Link href="/Admin/TotalUser">
              Full Details <span className="ml-2 font-bold">→</span>
              </Link>
              </div>
            </div>

            {/* Card 2 - Total Product */}
            <div className='bg-[#4bb7e9] text-gray-200 w-[450px] h-40 shadow-md flex flex-col justify-center rounded-sm items-center'>
              <div className='text-5xl font-bold mt-3'>10</div>
              <div className='text-3xl font-bold'>Availabe Donor</div>
              <div className="flex-grow"></div>
              <div className="bg-white w-full h-8 text-gray-600 text-center text-lg font-semibold">
              <Link href="/Admin/AvaiableDonor">
              Full Details <span className="ml-2 font-bold">→</span>
              </Link>
                </div>
            </div>
          </div>

          {/* Lower Section */}
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4 w-full justify-center pr-4 mt-4 pl-4 items-center ml-16">
            {/* Card 3 - Total Users */}
            <div className='bg-[#3ab7a2] text-gray-200 w-[450px] h-40 shadow-md flex flex-col justify-center rounded-sm items-center'>
              <div className='text-5xl font-bold mt-3'>{allHelppost}</div>
              <div className='text-3xl font-bold'>Help Request</div>
              <div className="flex-grow"></div>
              <div className="bg-white w-full cursor-pointer h-8 text-gray-600 text-center text-lg font-semibold">  
              <Link href="/Admin/HelpPost">
              Full Details <span className="ml-2 font-bold">→</span>
              </Link>
              </div>
            </div>

            {/* Card 4 - Total Donation */}
            <div className='bg-[#9d50be] text-gray-200 w-[450px] h-40 shadow-md flex flex-col justify-center rounded-sm items-center'>
              <div className='text-5xl font-bold mt-3'>45000</div>
              <div className='text-3xl font-bold'>Total Donation</div>
              <div className="flex-grow"></div>
              <div className="bg-white w-full h-8 text-gray-600 text-center text-lg font-semibold">
              <Link href="/Admin/MoneyDonor">
              Full Details <span className="ml-2 font-bold">→</span>
              </Link>
                </div>
            </div>
          </div>
        </div>
      </div>

</div>
  )
}

export default AdminDashboard