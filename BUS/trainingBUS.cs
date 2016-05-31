using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for UserBUS
    /// </summary>
    public class TrainingBUS
    {
        #region Initialization
        private TrainingDAO _trainingDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public TrainingBUS()
        {
            _trainingDAO = new TrainingDAO();
        }
        #endregion

        #region getTrainingList
        public List<TrainingVO> getTrainingList()
        {
            try
            {
                return _trainingDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getTrainingBindingList
        public BindingList<TrainingVO> getTrainingBindingList()
        {
            try
            {
                return _trainingDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
