// ManagerDashboard.jsx
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useRouter } from 'next/router';
 
const Dashboard = () => {
  const router = useRouter();
  const [allProducts, setAllProducts] = useState([]);
  const [error, setError] = useState('');
 
  useEffect(() => {
    // Fetch products when the component mounts
    GetProducts();
  }, []);
 
  const GetProducts = async () => {
    try {
      const response = await axios.get(
        'http://localhost:8086/spring-tutorial/users',
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      );
      if (response.data && response.data.products) {
        setAllProducts(response.data.products);
      } else {
        setError('Error fetching data');
      }
    } catch (error) {
      console.error('Failed:', error);
      setError(`An error occurred trying to fetch products: ${error.message}`);
    }
  };
 
  return (
    <div>
      
      <div className='col-span-12 bg-[#dfe4ea] text-[#192a56] pr-8 pl-8 shadow-md'>
        <div className="bg-[#dfe4ea] text-white min-h-screen ">
          <div className="container mx-auto">
            <h2 className="text-3xl font-bold mb-3 text-center text-[#192a56]">User Post</h2>
            <div className="flex justify-end mt-5">
              {/* Add Post */}
              <Link href="/User/AddPost">
                <div className="flex items-center bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded-md transition duration-300 cursor-pointer">
                  <BsPlus className="mr-2" />
                  Add Post
                </div>
              </Link>
            </div>

            <div className="mt-4">
              {allProducts.length > 0 ? (
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                  {allProducts.map((product) => (
                    <div key={product.id} className="w-full md:max-w-md mx-auto bg-white shadow-md rounded-md p-6">
                      <div className="flex items-center mb-4">
                        {/* Display user profile picture (you can replace this with your user image logic) */}
                        <div className="w-10 h-10 bg-gray-400 rounded-full mr-4"></div>
                        <div>
                          <h3 className="text-xl font-bold text-[#192a56]">{product.fullname}</h3>
                          <p className="text-gray-500">{/* Add timestamp or date here */}</p>
                        </div>
                      </div>
                    </div>
                  ))}
                </div>
              ) : (
                <div className="text-[#192a56]">{error || 'No products available'}</div>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
export default Dashboard;