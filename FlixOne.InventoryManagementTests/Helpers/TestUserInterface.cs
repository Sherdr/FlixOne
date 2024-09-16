using FlixOne.InventoryManagement.Interfaces;

namespace FlixOne.InventoryManagementTests.Helpers
{
    internal class TestUserInterface : IUserInterface
    {
        private int expectedWriteWarningRequestsIndex;
        private List<string> expectedWriteWarningRequests;

        private int expectedWriteMessageRequestsIndex;
        private List<string> expectedWriteMessageRequests;

        private int expectedReadValueRequestsIndex;
        private List<(string, string)> expectedReadValueRequests;

        public TestUserInterface(List<(string, string)> expectedReadValue, List<string> expectedWriteMessage, List<string> expectedWriteWarning) {
            expectedReadValueRequests = expectedReadValue;
            expectedWriteMessageRequests = expectedWriteMessage;
            expectedWriteWarningRequests = expectedWriteWarning;
        }

        public string ReadValue(string message)
        {
            Assert.IsTrue(expectedReadValueRequestsIndex < expectedReadValueRequests.Count,
                "Received too many command read value requests.");
            Assert.AreEqual(expectedReadValueRequests[expectedReadValueRequestsIndex].Item1, message,
                "Received unexpected command read message");
            return expectedReadValueRequests[expectedReadValueRequestsIndex++].Item2;
        }

        public void WriteMessage(string message)
        {
            Assert.IsTrue(expectedWriteMessageRequestsIndex < expectedWriteMessageRequests.Count,
                "Received too many command write message requests.");
            Assert.AreEqual(expectedWriteMessageRequests[expectedWriteMessageRequestsIndex++], message,
                "Received unexpected command write message");
        }

        public void WriteWarning(string message)
        {
            Assert.IsTrue(expectedWriteWarningRequestsIndex < expectedWriteWarningRequests.Count,
                "Received too many command write warning requests.");
            Assert.AreEqual(expectedWriteWarningRequests[expectedWriteWarningRequestsIndex++], message,
                "Received unexpected command write warning message");
        }

        public void Validate()
        {
            Assert.IsTrue(expectedReadValueRequestsIndex == expectedReadValueRequests.Count,
                "Not all read requests were performed.");
            Assert.IsTrue(expectedWriteMessageRequestsIndex == expectedWriteMessageRequests.Count,
                "Not all write requests were performed.");
            Assert.IsTrue(expectedWriteWarningRequestsIndex == expectedWriteWarningRequests.Count,
                "Not all warning requests were performed.");
        }
    }
}
